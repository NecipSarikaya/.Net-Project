using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey( l => l.Id);
            builder.Property(l => l.Name).HasMaxLength(35).IsRequired();
            builder.Property(l => l.NameUrl).HasMaxLength(35).IsRequired();
            builder.HasData(
                new Department(){Id=1,Name="Acil Yardım ve Afet Yönetimi",NameUrl="acil-yardim"},
                new Department(){Id=2,Name="Adli Bilimler",NameUrl="adli-bilimler"},
                new Department(){Id=3,Name="Aktüerya",NameUrl="aktuerya"},
                new Department(){Id=4,Name="Alman Dili ve Edebiyatı",NameUrl="alman-dili-edebiyati"},
                new Department(){Id=5,Name="Animasyon Oyun Tasarımı",NameUrl="animasyon-oyun-tasarimi"},
                new Department(){Id=6,Name="Antropoloji",NameUrl="antropoloji"},
                new Department(){Id=7,Name="Arap Dili ve Edebiyatı",NameUrl="arap-dili-edebiyatı"},
                new Department(){Id=8,Name="Arkeoloji",NameUrl="arkeoloji"},
                new Department(){Id=9,Name="Astronomi ve Uzay Bilimleri",NameUrl="astronomi"},
                new Department(){Id=10,Name="Bankacılık Finans Sigortacılık",NameUrl="bankacilik"},
                new Department(){Id=11,Name="Basın ve Yayın",NameUrl="basin-yayin"},
                new Department(){Id=12,Name="Beden Eğitimi ve Spor Öğretmenliği",NameUrl="beden-egitimi"},
                new Department(){Id=13,Name="Beslenme ve Diyetetik",NameUrl="beslenmediyetetik"},
                new Department(){Id=14,Name="Bilgisayar Mühendisliği",NameUrl="bilgisayarmühendisligi"},
                new Department(){Id=15,Name="Bilgisayar Teknolojileri ve Bilişim Sistemleri",NameUrl="bilisim"},
                new Department(){Id=16,Name="Bilim Tarihi",NameUrl="bilimtarihi"},
                new Department(){Id=17,Name="Biyokimya",NameUrl="biyokimya"},
                new Department(){Id=18,Name="Biyoloji",NameUrl="biyoloji"},
                new Department(){Id=19,Name="Biyomedikal Mühendisliği",NameUrl="biyomedikal"},
                new Department(){Id=20,Name="Biyomühendislik",NameUrl="biyomühendislik"},
                new Department(){Id=21,Name="Biyoteknoloji",NameUrl="biyoteknoloji"},
                new Department(){Id=22,Name="Çağdaş Türk Lehçeleri ve Edebiyatları",NameUrl="cagdas-turk-lehceleri"},
                new Department(){Id=23,Name="Çevre Mühendisliği",NameUrl="cevre-mühendisligi"},
                new Department(){Id=24,Name="Çocuk Gelişimi",NameUrl="cocuk-gelisimi"},
                new Department(){Id=25,Name="Coğrafya",NameUrl="cografya"},
                new Department(){Id=26,Name="Deniz İşletmeciliği ve Yönetimi",NameUrl="deniz-isletmeciligi"},
                new Department(){Id=27,Name="Deniz Ulaştırma İşletme Mühendisliği",NameUrl="deniz-ulastirma"},
                new Department(){Id=28,Name="Dijital Oyun Tasarımı",NameUrl="dijital-oyun-tasarimi"},
                new Department(){Id=29,Name="Dilbilim",NameUrl="dil-bilim"},
                new Department(){Id=30,Name="Diş Hekimliği",NameUrl="dis-hekimligi"},
                new Department(){Id=31,Name="Ebelik",NameUrl="ebelik"},
                new Department(){Id=32,Name="Eczacılık",NameUrl="eczacilik"},
                new Department(){Id=33,Name="Ekonomi",NameUrl="ekonomi"},
                new Department(){Id=34,Name="El Sanatları",NameUrl="el-sanatlari"},
                new Department(){Id=35,Name="Elektirik Elektronik Mühendisliği",NameUrl="elektiri-kmühendisligi"},
                new Department(){Id=36,Name="Elektronik Mühendisliği",NameUrl="elektronik-mühendisligi"},
                new Department(){Id=37,Name="Elektronik ve Haberleşme Mühendisliği",NameUrl="elektronik-haberlesme-mühendisligi"},
                new Department(){Id=38,Name="Endüstri Mühendisliği",NameUrl="endüstri-mühendisligi"},
                new Department(){Id=39,Name="Endüstri Tasarımı",NameUrl="endüstri-tasarimi"},
                new Department(){Id=40,Name="Enerji Mühendisliği",NameUrl="enerji-mühendisligi"},
                new Department(){Id=41,Name="Ergoterapi",NameUrl="ergoterapi"},
                new Department(){Id=42,Name="Felsefe",NameUrl="felsefe"},
                new Department(){Id=43,Name="Fen Bilgisi Öğretmenliği",NameUrl="fen-bilgisi"},
                new Department(){Id=44,Name="Film Tasarım ve Yazarlık",NameUrl="film-tasarimi"},
                new Department(){Id=45,Name="Finans ve Bankacılık",NameUrl="finans"},
                new Department(){Id=46,Name="Fizik",NameUrl="fizik"},
                new Department(){Id=47,Name="Fizik Mühendisliği",NameUrl="fizik-mühendisligi"},
                new Department(){Id=48,Name="Fizyoterapi ve Rehabilitasyon",NameUrl="fizyoterapi"},
                new Department(){Id=49,Name="Fransız Dili ve Edebiyatı",NameUrl="fransiz-dili-edebiyati"},
                new Department(){Id=50,Name="Gastronomi",NameUrl="gastronomi"},
                new Department(){Id=51,Name="Gazetecilik",NameUrl="gazetecilik"},
                new Department(){Id=52,Name="Gemi İnşaatı ve Makineleri Mühendisliği",NameUrl="gemi-insaati"},
                new Department(){Id=53,Name="Gıda Mühendisliği",NameUrl="gida-mühendisligi"},
                new Department(){Id=54,Name="Girişimcilik",NameUrl="girisimcilik"},
                new Department(){Id=55,Name="Görsel Sanatlar",NameUrl="görsel-sanatlar"},
                new Department(){Id=56,Name="Grafik Tasarımı",NameUrl="grafik-tasarim"},
                new Department(){Id=57,Name="Gümrük İşletme",NameUrl="gümrük-isletme"},
                new Department(){Id=58,Name="Halkla İlişkiler",NameUrl="halkla-iliskiler"},
                new Department(){Id=59,Name="Harita Mühendisliği",NameUrl="harita-mühendisligi"},
                new Department(){Id=60,Name="Havacılık Elektirik ve Elektroniği",NameUrl="havacilik-elektiril-elektronik"},
                new Department(){Id=61,Name="Havacılık ve Uzay Mühendisliği",NameUrl="havacilik-ve-uzay"},
                new Department(){Id=62,Name="Hemşirelik",NameUrl="hemsirelik"},
                new Department(){Id=63,Name="Hukuk",NameUrl="hukuk"},
                new Department(){Id=64,Name="İç Mimarlık",NameUrl="ic-mimarlik"},
                new Department(){Id=65,Name="İktisat",NameUrl="iktisat"},
                new Department(){Id=66,Name="İlahiyat",NameUrl="ilahiyat"},
                new Department(){Id=67,Name="İletişim",NameUrl="iletisim"},
                new Department(){Id=68,Name="İmalat Mühendisliği",NameUrl="imalat-mühendisligi"},
                new Department(){Id=69,Name="İngiliz Dili ve Edebiyatı",NameUrl="ingiliz-dili-edebiyati"},
                new Department(){Id=70,Name="İnşaat Mühendisliği",NameUrl="insaat-mühendisligi"},
                new Department(){Id=71,Name="İnsan Kaynakları Yönetimi",NameUrl="insan-kaynaklari"},
                new Department(){Id=72,Name="İş Sağlığı ve Güvenliği",NameUrl="is-sagligi"},
                new Department(){Id=73,Name="İslami Bilimler",NameUrl="islami-bilimler"},
                new Department(){Id=74,Name="İşletme",NameUrl="isletme"},
                new Department(){Id=75,Name="İstatistik",NameUrl="istatistik"},
                new Department(){Id=76,Name="Jeofizik Mühendisliği",NameUrl="jeofizik-mühendisligi"},
                new Department(){Id=77,Name="Kamu Yönetimi",NameUrl="kamu-yönetimi"},
                new Department(){Id=78,Name="Kimya",NameUrl="kimya"},
                new Department(){Id=79,Name="Kimya Mühendisliği",NameUrl="kimya-mühendisligi"},
                new Department(){Id=80,Name="Konaklama İşletmeciliği",NameUrl="konaklama"},
                new Department(){Id=81,Name="Kontrol ve Otomasyon Mühendisliği",NameUrl="kontrol-otomasyon-mühendisligi"},
                new Department(){Id=82,Name="Küresel Siyaset ve Uluslarası İlişkiler",NameUrl="küresel-siyaset-uluslarası-iliskiler"},
                new Department(){Id=83,Name="Kürt Dili ve Edebiyatı",NameUrl="kürt-dili-edebiyati"},
                new Department(){Id=84,Name="Kuyumculuk ve Mücevher Tasarımı",NameUrl="kuyumculuk-mücevher-tasarimi"},
                new Department(){Id=85,Name="Latin Dili ve Edebiyatı",NameUrl="latin-dili-edebiyati"},
                new Department(){Id=86,Name="Lojistik",NameUrl="lojistik"},
                new Department(){Id=87,Name="Maden Mühendisliği",NameUrl="maden-mühendisligi"},
                new Department(){Id=88,Name="Makine Mühendisliği",NameUrl="makine-mühendisligi"},
                new Department(){Id=89,Name="Makine ve İmalat Mühendisliği",NameUrl="makine-imalat-mühendisligi"},
                new Department(){Id=90,Name="Maliye",NameUrl="maliye"},
                new Department(){Id=91,Name="Malzeme Bilimi ve Mühendisliği",NameUrl="malzeme"},
                new Department(){Id=92,Name="Matematik",NameUrl="matematik"},
                new Department(){Id=93,Name="Matematik Mühendisliği",NameUrl="matematik-mühendsiligi"},
                new Department(){Id=94,Name="Matematik Öğretmenliği",NameUrl="matematik-ögretmenligi"},
                new Department(){Id=95,Name="Medya ve İletişim",NameUrl="medya-iletisim"},
                new Department(){Id=96,Name="Mekatronik Mühendislği",NameUrl="mekatronik-mühendisligi"},
                new Department(){Id=97,Name="Metalurji ve Malzeme Mühendisliği",NameUrl="metalurji-malzeme-mühendisligi"},
                new Department(){Id=98,Name="Meteoroloji Mühendisliği",NameUrl="meteoroloji-mühendisligi"},
                new Department(){Id=99,Name="Mimarlık",NameUrl="mimarlik"},
                new Department(){Id=100,Name="Moda Tasarımı",NameUrl="moda-tasarim"},
                new Department(){Id=101,Name="Moleküler Biyoloji ve Genetik",NameUrl="moleküler-biyoloji-genetik"},
                new Department(){Id=102,Name="Muhasebe",NameUrl="muhasebe"},
                new Department(){Id=103,Name="Mütercim Tercümanlık",NameUrl="mütercim-tercüman"},
                new Department(){Id=104,Name="Müzecilik",NameUrl="müzecilik"},
                new Department(){Id=105,Name="Nanoteknoloji Mühendisliği",NameUrl="nano-teknoloji-mühendisligi"},
                new Department(){Id=106,Name="Odyoloji",NameUrl="odyoloji"},
                new Department(){Id=107,Name="Okul Öncesi Öğretmenliği",NameUrl="okul-öncesi-ögretmenligi"},
                new Department(){Id=108,Name="Optik ve Akustik Mühendisliği",NameUrl="optik-akustik-mühendisligi"},
                new Department(){Id=109,Name="Ortez-Protez",NameUrl="ortez-protez"},
                new Department(){Id=110,Name="Otomotiv Mühendisliği",NameUrl="otomotiv-mühendisligi"},
                new Department(){Id=111,Name="Pazarlama",NameUrl="pazarlama"},
                new Department(){Id=112,Name="Petrol ve Doğalgaz Mühendisliği",NameUrl="petrol-dogalgaz-mühendisligi"},
                new Department(){Id=113,Name="Peyzaj Mimarlığı",NameUrl="peyzaj-mimarligi"},
                new Department(){Id=114,Name="Pilotaj",NameUrl="pilotaj"},
                new Department(){Id=115,Name="Psikoloji",NameUrl="psikoloji"},
                new Department(){Id=116,Name="Radyo ve Televizyon",NameUrl="radyo-televizyon"},
                new Department(){Id=117,Name="Rehberlik ve Psikolojik Danışmanlık",NameUrl="rehberlik"},
                new Department(){Id=118,Name="Raklamcılık",NameUrl="reklamcilik"},
                new Department(){Id=119,Name="Rekreasyon",NameUrl="rekreasyon"},
                new Department(){Id=120,Name="Rus Dili ve Edebiyatı",NameUrl="rus-dili-edebiyati"},
                new Department(){Id=121,Name="Sağlık Yönetimi",NameUrl="saglik-yönetimi"},
                new Department(){Id=122,Name="Sanat Tarihi",NameUrl="sanat-tarihi"},
                new Department(){Id=123,Name="Şehir ve Bölge Planlama",NameUrl="sehir-bölge-planlama"},
                new Department(){Id=124,Name="Sermaye Piyasaları ve Portföy Yönetimi",NameUrl="sermaye-piyasalari-portfoy-yonetimi"},
                new Department(){Id=125,Name="Seyahat İşletmeciliği",NameUrl="seyahat-isletmeciligi"},
                new Department(){Id=126,Name="Sigortacılık",NameUrl="sigortacilik"},
                new Department(){Id=127,Name="Sinema ve Televizyon",NameUrl="sinema-televizyon"},
                new Department(){Id=128,Name="Sınıf Öğretmenliği",NameUrl="sinif-ögretmenligi"},
                new Department(){Id=129,Name="Siyasal Bilimler",NameUrl="siyasal-bilimler"},
                new Department(){Id=130,Name="Sosyal Hizmet",NameUrl="sosyal-hizmet"},
                new Department(){Id=131,Name="Sosyoloji",NameUrl="sosyoloji"},
                new Department(){Id=132,Name="Spor Yöneticiliği",NameUrl="spor-yöneticiligi"},
                new Department(){Id=133,Name="Su Bilimleri Mühendisliği",NameUrl="su-bilimleri-mühendisligi"},
                new Department(){Id=134,Name="Tarih",NameUrl="tarih"},
                new Department(){Id=135,Name="Tarım Ekonomisi",NameUrl="tarim-ekonomisi"},
                new Department(){Id=136,Name="Tarımsal Biyoteknoloji",NameUrl="tarimsal-biyoloji"},
                new Department(){Id=137,Name="Tekstil Mühendisliği",NameUrl="tekstil-mühendisligi"},
                new Department(){Id=138,Name="Tıp",NameUrl="tip"},
                new Department(){Id=139,Name="Tıp Mühendisliği",NameUrl="tip-mühendisligi"},
                new Department(){Id=140,Name="Turizm İşletmeciliği",NameUrl="turizm-isletmeciligi"},
                new Department(){Id=141,Name="Türk Dili ve Edebiyatı",NameUrl="türk-dili-edebiyati"},
                new Department(){Id=142,Name="Türkoloji",NameUrl="türkoloji"},
                new Department(){Id=143,Name="Uçak Mühendisliği",NameUrl="ucak-mühendisligi"},
                new Department(){Id=144,Name="Ulaştırma ve Lojistik",NameUrl="ulastirma-ve-lojistik"},
                new Department(){Id=145,Name="Uluslarası Finans",NameUrl="uluslarasi-finans"},
                new Department(){Id=146,Name="Uluslarası İlişkiler",NameUrl="uluslarasi-iliskiler"},
                new Department(){Id=147,Name="Uluslarası İşletmecilik",NameUrl="uluslarasi-isletmecilik"},
                new Department(){Id=148,Name="Uluslarası Lojistik",NameUrl="uluslarasi-lojistik"},
                new Department(){Id=149,Name="Uluslarası Ticaret",NameUrl="uluslarasi-ticaret"},
                new Department(){Id=150,Name="Uzay Mühendisliği",NameUrl="uzay-mühendisligi"},
                new Department(){Id=151,Name="Veterinerlik",NameUrl="veterinerlik"},
                new Department(){Id=152,Name="Yazılım Mühendisliği",NameUrl="yazilim-mühendisligi"},
                new Department(){Id=153,Name="Yeni Medya",NameUrl="yeni-medya"},
                new Department(){Id=154,Name="Ziraat Mühendisliği Programları",NameUrl="ziraat-mühendisligi"},
                new Department(){Id=155,Name="Zootekni",NameUrl="zootekni"},
                new Department(){Id=1000,Name="none",NameUrl="none"}
            );
        }
    }
}