using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TeknikMarket.Model.Entity
{
    public partial class TeknikMarketDBContext : DbContext
    {
        public TeknikMarketDBContext()
        {
        }

        public TeknikMarketDBContext(DbContextOptions<TeknikMarketDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banka> Bankas { get; set; } = null!;
        public virtual DbSet<Firma> Firmas { get; set; } = null!;
        public virtual DbSet<Il> Ils { get; set; } = null!;
        public virtual DbSet<Kampanya> Kampanyas { get; set; } = null!;
        public virtual DbSet<KampanyaTipi> KampanyaTipis { get; set; } = null!;
        public virtual DbSet<Kategori> Kategoris { get; set; } = null!;
        public virtual DbSet<Kullanici> Kullanicis { get; set; } = null!;
        public virtual DbSet<KullaniciRol> KullaniciRols { get; set; } = null!;
        public virtual DbSet<Marka> Markas { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Sehir> Sehirs { get; set; } = null!;
        public virtual DbSet<Sepet> Sepets { get; set; } = null!;
        public virtual DbSet<Sipari> Siparis { get; set; } = null!;
        public virtual DbSet<SiparisDetay> SiparisDetays { get; set; } = null!;
        public virtual DbSet<SiparisKampanya> SiparisKampanyas { get; set; } = null!;
        public virtual DbSet<StokBirim> StokBirims { get; set; } = null!;
        public virtual DbSet<TaksitSecenek> TaksitSeceneks { get; set; } = null!;
        public virtual DbSet<Urun> Uruns { get; set; } = null!;
        public virtual DbSet<UrunFiyat> UrunFiyats { get; set; } = null!;
        public virtual DbSet<UrunFotograf> UrunFotografs { get; set; } = null!;
        public virtual DbSet<UrunResim> UrunResims { get; set; } = null!;
        public virtual DbSet<Yonetici> Yoneticis { get; set; } = null!;
        public virtual DbSet<YoneticiRol> YoneticiRols { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-59P51TM\\TEW_SQLEXPRESS;Database=TeknikMarketDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banka>(entity =>
            {
                entity.ToTable("Banka");

                entity.Property(e => e.BankaAdi).HasMaxLength(50);

                entity.Property(e => e.BankaIcon).HasMaxLength(250);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Firma>(entity =>
            {
                entity.ToTable("Firma");

                entity.Property(e => e.FirmaAdi).HasMaxLength(500);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.TckimlikNo)
                    .HasMaxLength(11)
                    .HasColumnName("TCKimlikNo");

                entity.Property(e => e.VergiDairesi).HasMaxLength(50);

                entity.Property(e => e.VergiNumarasi).HasMaxLength(50);

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Firmas)
                    .HasForeignKey(d => d.KullaniciId)
                    .HasConstraintName("FK_Firma_Kullanici");
            });

            modelBuilder.Entity<Il>(entity =>
            {
                entity.ToTable("il");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.IlAdi)
                    .HasMaxLength(50)
                    .HasColumnName("ilAdi");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Kampanya>(entity =>
            {
                entity.ToTable("Kampanya");

                entity.Property(e => e.Aciklama).HasMaxLength(250);

                entity.Property(e => e.Baslik).HasMaxLength(50);

                entity.Property(e => e.Deger).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.KampanyaTipi)
                    .WithMany(p => p.Kampanyas)
                    .HasForeignKey(d => d.KampanyaTipiId)
                    .HasConstraintName("FK_Kampanya_KampanyaTipi");
            });

            modelBuilder.Entity<KampanyaTipi>(entity =>
            {
                entity.ToTable("KampanyaTipi");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Tip).HasMaxLength(50);
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("Kategori");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.KategoriAdi).HasMaxLength(50);

                entity.Property(e => e.KategoriGorunum).HasMaxLength(150);

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.UstKategori)
                    .WithMany(p => p.InverseUstKategori)
                    .HasForeignKey(d => d.UstKategoriId)
                    .HasConstraintName("FK_Kategori_Kategori");
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanici");

                entity.Property(e => e.Adi).HasMaxLength(50);

                entity.Property(e => e.DogumTarihi).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.IlId).HasColumnName("ilId");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Sifre).HasMaxLength(200);

                entity.Property(e => e.Soyadi).HasMaxLength(50);

                entity.HasOne(d => d.Il)
                    .WithMany(p => p.Kullanicis)
                    .HasForeignKey(d => d.IlId)
                    .HasConstraintName("FK_Kullanici_il");

                entity.HasOne(d => d.IlNavigation)
                    .WithMany(p => p.Kullanicis)
                    .HasForeignKey(d => d.IlId)
                    .HasConstraintName("FK_Kullanici_Sehir");
            });

            modelBuilder.Entity<KullaniciRol>(entity =>
            {
                entity.ToTable("KullaniciRol");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Kullanıcı)
                    .WithMany(p => p.KullaniciRols)
                    .HasForeignKey(d => d.KullanıcıId)
                    .HasConstraintName("FK_KullaniciRol_Kullanici");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.KullaniciRols)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_KullaniciRol_Rol");
            });

            modelBuilder.Entity<Marka>(entity =>
            {
                entity.ToTable("Marka");

                entity.Property(e => e.Aciklama).HasMaxLength(250);

                entity.Property(e => e.FirmaResmi).HasMaxLength(250);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.MarkaAdi).HasMaxLength(100);

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.RolAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<Sehir>(entity =>
            {
                entity.ToTable("Sehir");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.SehirAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<Sepet>(entity =>
            {
                entity.ToTable("Sepet");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.ToplamTutar).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.Sepets)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_Sepet_Urun");
            });

            modelBuilder.Entity<Sipari>(entity =>
            {
                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.SiparisTarihi).HasColumnType("datetime");

                entity.Property(e => e.ToplamSiparisTutari).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Siparis)
                    .HasForeignKey(d => d.KullaniciId)
                    .HasConstraintName("FK_Siparis_Kullanici");
            });

            modelBuilder.Entity<SiparisDetay>(entity =>
            {
                entity.ToTable("SiparisDetay");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Siparis)
                    .WithMany(p => p.SiparisDetays)
                    .HasForeignKey(d => d.SiparisId)
                    .HasConstraintName("FK_SiparisDetay_Siparis");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SiparisDetays)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_SiparisDetay_Urun");
            });

            modelBuilder.Entity<SiparisKampanya>(entity =>
            {
                entity.ToTable("SiparisKampanya");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Kampanya)
                    .WithMany(p => p.SiparisKampanyas)
                    .HasForeignKey(d => d.KampanyaId)
                    .HasConstraintName("FK_SiparisKampanya_Kampanya");

                entity.HasOne(d => d.Siparis)
                    .WithMany(p => p.SiparisKampanyas)
                    .HasForeignKey(d => d.SiparisId)
                    .HasConstraintName("FK_SiparisKampanya_Siparis");
            });

            modelBuilder.Entity<StokBirim>(entity =>
            {
                entity.ToTable("StokBirim");

                entity.Property(e => e.BirimAdi).HasMaxLength(50);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<TaksitSecenek>(entity =>
            {
                entity.ToTable("TaksitSecenek");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Banka)
                    .WithMany(p => p.TaksitSeceneks)
                    .HasForeignKey(d => d.BankaId)
                    .HasConstraintName("FK_TaksitSecenek_Banka");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.TaksitSeceneks)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_TaksitSecenek_Urun");
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.ToTable("Urun");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.UrunAdi).HasMaxLength(150);

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Uruns)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Urun_Kategori");
            });

            modelBuilder.Entity<UrunFiyat>(entity =>
            {
                entity.ToTable("UrunFiyat");

                entity.Property(e => e.Aciklama).HasMaxLength(250);

                entity.Property(e => e.Baslik).HasMaxLength(50);

                entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.UrunFiyats)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_UrunFiyat_Urun");
            });

            modelBuilder.Entity<UrunFotograf>(entity =>
            {
                entity.ToTable("UrunFotograf");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.UrunFotografs)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_UrunFotograf_Urun");
            });

            modelBuilder.Entity<UrunResim>(entity =>
            {
                entity.ToTable("UrunResim");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimYolu).HasMaxLength(500);

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.UrunResims)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_UrunResim_Urun");
            });

            modelBuilder.Entity<Yonetici>(entity =>
            {
                entity.ToTable("Yonetici");

                entity.Property(e => e.Adi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Resim).HasMaxLength(250);

                entity.Property(e => e.Sifre).HasMaxLength(50);

                entity.Property(e => e.Soyadi).HasMaxLength(50);
            });

            modelBuilder.Entity<YoneticiRol>(entity =>
            {
                entity.ToTable("YoneticiRol");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.YoneticiRols)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_YoneticiRol_Rol");

                entity.HasOne(d => d.Yonetici)
                    .WithMany(p => p.YoneticiRols)
                    .HasForeignKey(d => d.YoneticiId)
                    .HasConstraintName("FK_YoneticiRol_Yonetici");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
