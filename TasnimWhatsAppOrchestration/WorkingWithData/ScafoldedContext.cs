using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TasnimWhatsAppOrchestration.Models;

#nullable disable

namespace TasnimWhatsAppOrchestration.WorkingWithData
{
    public partial class ScafoldedContext : DbContext
    {
        public ScafoldedContext()
        {
        }

        public ScafoldedContext(DbContextOptions<TasnimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FileCustomer> FileCustomers { get; set; }
        public virtual DbSet<FileCustomerMobile> FileCustomerMobiles { get; set; }
        public virtual DbSet<FileListed> FileListeds { get; set; }
        public virtual DbSet<HusoomatWhatsappOffer> HusoomatWhatsappOffers { get; set; }
        public virtual DbSet<OnlineRegistrationInfo> OnlineRegistrationInfos { get; set; }
        public virtual DbSet<OnlineRegistrationSource> OnlineRegistrationSources { get; set; }
        public virtual DbSet<OsSubCod> OsSubCods { get; set; }
        public virtual DbSet<SessionCardHeader> SessionCardHeaders { get; set; }
        public virtual DbSet<SessionCardType> SessionCardTypes { get; set; }
        public virtual DbSet<WhatsappOffer> WhatsappOffers { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FileCustomer>(entity =>
            {
                entity.ToTable("FileCustomer");

                entity.HasIndex(e => e.CareStpId, "IX_FileCustomer_CARE");

                entity.HasIndex(e => new { e.Mobile, e.IsMerge }, "IX_FileCustomer_MobileIsMerge");

                entity.Property(e => e.Address).HasComment("العنوان");

                entity.Property(e => e.CardId)
                    .HasMaxLength(250)
                    .HasComment("رقم البطاقه");

                entity.Property(e => e.CareStpId)
                    .HasColumnName("CARE_STP_Id")
                    .HasComment("رقم ذمة العميل في ملف الذمم ");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasComment("تاريخ الإنشاء");

                entity.Property(e => e.DateofBirth)
                    .HasColumnType("date")
                    .HasComment("تاريخ الميلاد");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasComment("البريد الإلكتروني");

                entity.Property(e => e.Gender).HasComment("الجنس");

                entity.Property(e => e.IdentifyWayId).HasComment("وسيلة التعرف");

                entity.Property(e => e.InsertedUserId).HasColumnName("InsertedUserID");

                entity.Property(e => e.IsMerge).HasComment("تم دمج الملف");

                entity.Property(e => e.Job)
                    .HasMaxLength(500)
                    .HasComment("الوظيفه")
                    .UseCollation("Arabic_CS_AS");

                entity.Property(e => e.MarketingPlaceId).HasColumnName("MarketingPlaceID");

                entity.Property(e => e.Mobile).HasComment("الجوال");

                entity.Property(e => e.MobileVerificationId).HasColumnName("MobileVerificationID");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasComment("الإسم")
                    .UseCollation("Arabic_CS_AS");

                entity.Property(e => e.Nationality).HasComment("الجنسية");

                entity.Property(e => e.NewId).HasComment("رقم الملف الجديد بعد الدمج");

                entity.Property(e => e.OfficialEndDate)
                    .HasColumnType("date")
                    .HasComment("تاريخ إنتهاء الوثيقة");

                entity.Property(e => e.OfficialId).HasComment("نوع الوثيقة");

                entity.Property(e => e.OfficialNumber)
                    .HasMaxLength(500)
                    .HasComment("رقم الوثيقة")
                    .UseCollation("Arabic_CS_AS");

                entity.Property(e => e.PersonalImage).HasComment("الصورة الشخصية");

                entity.Property(e => e.SmsTrue).HasColumnName("SMS_TRUE");

                entity.Property(e => e.Telephone).HasComment("الهاتف");
            });

            modelBuilder.Entity<FileCustomerMobile>(entity =>
            {
                entity.ToTable("FileCustomerMobile");

                entity.HasIndex(e => new { e.Mobile, e.MobileKey }, "IX_FileCustomerMobile")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FileCustomerId).HasColumnName("FileCustomerID");

                entity.Property(e => e.InsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertedUserId).HasColumnName("InsertedUserID");
            });

            modelBuilder.Entity<FileListed>(entity =>
            {
                entity.ToTable("FileListed");

                entity.HasIndex(e => e.FileCustemerId, "IX_FileListed_I");

                entity.HasIndex(e => e.SubCod, "IX_FileListed_SUB_COD");

                entity.Property(e => e.Id).HasComment("رمز القائمة السوداء");

                entity.Property(e => e.ApproveDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("تاربخ الأنشاء");

                entity.Property(e => e.EmpApprovedId).HasComment("رمز الموظف");

                entity.Property(e => e.EmpId)
                    .HasColumnName("Emp_Id")
                    .HasComment("رمز المظف");

                entity.Property(e => e.FileCustemerId).HasComment("رمز العمبل");

                entity.Property(e => e.FileListedHistoryId).HasColumnName("FileListedHistoryID");

                entity.Property(e => e.IsApproved).HasComment("الحالة");

                entity.Property(e => e.IsListed).HasComment("المدرج في الجدول");

                entity.Property(e => e.ListReason)
                    .HasMaxLength(400)
                    .HasComment("قائمة السبب");

                entity.Property(e => e.Notes)
                    .HasMaxLength(400)
                    .HasComment("ملاحظات");

                entity.Property(e => e.SubCod)
                    .HasColumnName("SUB_COD")
                    .HasComment("رمز تفاصيل ");

                entity.Property(e => e.ValidatedInDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SubCodNavigation)
                    .WithMany(p => p.FileListeds)
                    .HasForeignKey(d => d.SubCod)
                    .HasConstraintName("FK_FileListed_OS_SUB_COD");
            });

            modelBuilder.Entity<HusoomatWhatsappOffer>(entity =>
            {
                entity.ToTable("HusoomatWhatsappOffer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertUserId).HasColumnName("insertUserId");

                entity.Property(e => e.OfferName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<OnlineRegistrationInfo>(entity =>
            {
                entity.ToTable("OnlineRegistrationInfo");

                entity.HasIndex(e => new { e.FileCustomerId, e.CreateDate }, "IX_OnlineRegistrationInfo")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CancelDateTime).HasColumnType("datetime");

                entity.Property(e => e.CancelUserId).HasColumnName("CancelUserID");

                entity.Property(e => e.CityStpId).HasColumnName("CITY_STP_ID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.CsaId).HasColumnName("CSA_ID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenderId).HasColumnName("GENDER_ID");

                entity.Property(e => e.MatStpId).HasColumnName("MAT_STP_ID");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OnlineRegistrationSourceId).HasColumnName("OnlineRegistrationSourceID");

                entity.HasOne(d => d.OnlineRegistrationSource)
                    .WithMany(p => p.OnlineRegistrationInfos)
                    .HasForeignKey(d => d.OnlineRegistrationSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineRegistrationInfo_OnlineRegistrationSource");
            });

            modelBuilder.Entity<OnlineRegistrationSource>(entity =>
            {
                entity.ToTable("OnlineRegistrationSource");

                entity.HasIndex(e => e.SourceCode, "IX_OnlineRegistrationSource")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SourceCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SourceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OsSubCod>(entity =>
            {
                entity.HasKey(e => e.SubCodId)
                    .HasName("PK_OS_SUB_COD_1");

                entity.ToTable("OS_SUB_COD");

                entity.Property(e => e.SubCodId).HasColumnName("SUB_COD_ID");

                entity.Property(e => e.ActCodId).HasColumnName("ACT_COD_ID");

                entity.Property(e => e.MstrId).HasColumnName("MSTR_ID");

                entity.Property(e => e.OrgStpId).HasColumnName("ORG_STP_ID");

                entity.Property(e => e.SubCod).HasColumnName("SUB_COD");

                entity.Property(e => e.SubNmFrn).HasColumnName("SUB_NM_FRN");

                entity.Property(e => e.SubNmNtv).HasColumnName("SUB_NM_NTV");
            });

            modelBuilder.Entity<SessionCardHeader>(entity =>
            {
                entity.ToTable("SessionCardHeader");

                entity.HasIndex(e => e.MatStpId, "IX_SessionCardHeader")
                    .IsUnique();

                entity.Property(e => e.DmnDtlId)
                    .HasColumnName("DMN_DTL_ID")
                    .HasComment("طريقة الجدولة");

                entity.Property(e => e.HelperAvgWorkMinutes)
                    .HasColumnName("HELPER_AVG_WORK_MINUTES")
                    .HasComment("مدة عمل المساعد بالجلسة");

                entity.Property(e => e.IsFreeConsultancy)
                    .HasDefaultValueSql("((0))")
                    .HasComment("جلسة إستشارية نعم-لا");

                entity.Property(e => e.LastEditDate).HasColumnType("datetime");

                entity.Property(e => e.MatCatId)
                    .HasColumnName("MAT_CAT_ID")
                    .HasComment("فئات المواد ");

                entity.Property(e => e.MatStpId)
                    .HasColumnName("MAT_STP_ID")
                    .HasComment("المواد ");

                entity.Property(e => e.NoAssetsUsed).HasColumnName("NO_ASSETS_USED");

                entity.Property(e => e.NoMaterialsUsed).HasColumnName("NO_MATERIALS_USED");

                entity.Property(e => e.OrgStpId).HasColumnName("ORG_STP_ID");

                entity.Property(e => e.SchDuration)
                    .HasColumnName("SCH_DURATION")
                    .HasComment("مدة الجلسه بالدقائق ");

                entity.Property(e => e.SpecialistAvgWorkMinutes)
                    .HasColumnName("SPECIALIST_AVG_WORK_MINUTES")
                    .HasComment("مدة عمل الأخصائي بالجلسة");

                entity.HasOne(d => d.SessionCardType)
                    .WithMany(p => p.SessionCardHeaders)
                    .HasForeignKey(d => d.SessionCardTypeId)
                    .HasConstraintName("FK_SessionCardHeader_SessionCardType");
            });

            modelBuilder.Entity<SessionCardType>(entity =>
            {
                entity.ToTable("SessionCardType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypNmFrn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TYP_NM_FRN");

                entity.Property(e => e.TypNmNtv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TYP_NM_NTV");
            });

            modelBuilder.Entity<WhatsappOffer>(entity =>
            {
                entity.ToTable("WhatsappOffer");

                entity.HasIndex(e => e.OfferName, "IX_WhatsappOffer")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertedUserId).HasColumnName("InsertedUserID");

                entity.Property(e => e.OfferName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.HasSequence("CountBy");

            OnModelCreatingPartial(modelBuilder);
            OnTansimeModeolCreaing( modelBuilder);
        }


        public virtual void  OnTansimeModeolCreaing(ModelBuilder modelBuilder)
        {

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
