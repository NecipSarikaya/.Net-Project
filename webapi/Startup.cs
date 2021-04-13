using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using webapi.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using webapi.DTO.HelpersDTO;
using data.Concrete;
using entity;
using business.Abstract;
using business.Concrete;
using data.Abstract;
using webui.Identity;

namespace webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }
        private readonly string MyAllowOrigins = "_myAllowOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddDbContext<MentorContext>(options => options.UseSqlite(_configuration["ConnectionStrings:DbConnectionString"],
                options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                ));
            
            services.AddIdentity<User,Role>().AddEntityFrameworkStores<MentorContext>().AddDefaultTokenProviders();
            
            services.Configure<IdentityOptions>(options =>{

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                // options.User.AllowedUserNameCharacters = "";

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 3;

                options.SignIn.RequireConfirmedPhoneNumber=false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;

                options.User.RequireUniqueEmail= true;
                options.User.AllowedUserNameCharacters="QWERTYUIOPĞÜİŞLKJHGFDSAZXCVBNMÖÇqwertyuıopğüişlkjhgfdsazxcvbnmöç.:;é!'^+%&/()=?_<>£#$½{[]}1234567890<>|/*-+";
            });
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUniPostImageService,UniPostImageManager>();
            services.AddScoped<ICatPostImageService,CatPostImageManager>();
            services.AddScoped<IUserFollowUserService,UserFollowUserManager>();
            services.AddScoped<IUniDepService,UniDepManager>();
            services.AddScoped<IUserService,UserManager>();
            services.AddScoped<IUniversityService,UniversityManager>();
            services.AddScoped<IUniPostLikeService,UniPostLikeManager>();
            services.AddScoped<IUniCommentService,UniCommentManager>();
            services.AddScoped<IUniCommentLikeService,UniCommentLikeManager>();
            services.AddScoped<IDepartmentService,DepartmentManager>();
            services.AddScoped<ICatPostService,CatPostManager>();
            services.AddScoped<ICatPostLikeService,CatPostLikeManager>();
            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddScoped<ICatCommentService,CatCommentManager>();
            services.AddScoped<ICatCommentLikeService,CatCommentLikeManager>();
            services.AddScoped<IUniPostService,UniPostManager>();

            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IUniDepRepository,EfCoreUniDepRepository>();
            
            services.AddScoped<IEmailSender,SmtpEmailSender>(i =>
                new SmtpEmailSender(
                    _configuration["EmailSender:Host"],
                    _configuration.GetValue<int>("EmailSender:Port"),
                    _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    _configuration["EmailSender:UserName"],
                    _configuration["EmailSender:Password"]
                )
            );
            services.AddControllers().AddNewtonsoftJson(options=>{
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            
            services.AddCors(options =>{
                options.AddPolicy(
                    name: MyAllowOrigins,
                    builder => {
                        builder
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "webapi", Version = "v1" });
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(UserManager<User> _userManager,RoleManager<Role> _roleManager,IConfiguration _configuration,IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "webapi v1"));
            }else{
                app.UseExceptionHandler(appError=>{
                    appError.Run(async context =>{
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var exception = context.Features.Get<IExceptionHandlerFeature>();
                        if(exception != null)
                        {
                            await context.Response.WriteAsync(new ErrorDetails(){
                                StatusCode = context.Response.StatusCode,
                                Message = exception.Error.Message
                            }.ToString());
                        }
                    }); 
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseStaticFiles();

            app.UseCors(MyAllowOrigins);

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            SeedIdentity.Seed(_userManager,_roleManager,_configuration).Wait();
        }
    }
}
