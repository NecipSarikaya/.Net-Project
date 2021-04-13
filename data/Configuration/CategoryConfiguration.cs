using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name).HasMaxLength(35).IsRequired();
            builder.Property(l => l.NameUrl).HasMaxLength(35).IsRequired();
            builder.Property(l => l.ImageUrl).HasMaxLength(120).IsRequired();
            builder.Property(l => l.Description).HasMaxLength(200).IsRequired();
            builder.HasData(
                new Category(){Id=1,Name="Yazılım",NameUrl="yazilim",ImageUrl="kodlama.jfif",Description="Herhangi bir dilde karşılaştığınız problemlere analitik çözümler bulabilirsin ve insanlara sorunlarını çözmekte yardım edebilirsin."},
                new Category(){Id=2,Name="Grafik Tasarım",NameUrl="grafiktasarim",ImageUrl="grafiktasarimi.png",Description="Grafik Tasarımı hakkında aklınıza takılan her soruya cevap bulabilir ve insanlara sorunlarını çözmekte yardım edebilirsin."},
                new Category(){Id=3,Name="YKS Sınavı",NameUrl="yks",ImageUrl="tyt-ayt.jpg",Description="Üniversite sınavına hazırlanırken sana gereken desteği ve motivasyonu burada bulabilirsin ve insanlara yardım edebilirsin"},
                new Category(){Id=4,Name="Kitap",NameUrl="kitap",ImageUrl="kitap.jpg",Description="Okuduğunuz kitaplar hakkında insanlarla tartışabilir ve fikir alışverişinde bulunabilirsin ve insanlara sorunlarını çözmekte yardım edebilirsin."}
            );
        }
    }
}