using BridgeManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace BridgeManagement.DataAccessLayer
{
	public partial class BmtContext : DbContext
	{
		public virtual DbSet<ImportLog> ImportLog { get; set; }
		public virtual DbSet<InterfaceInfo> InterfaceInfo { get; set; }
		public virtual DbSet<ObjectMetadata> ObjectMetadata { get; set; }
		public virtual DbSet<ObjectMetadataDefinition> ObjectMetadataDef { get; set; }
		public virtual DbSet<ProcessedObject> ProcessedObject { get; set; }
		public virtual DbSet<RecordInfo> RecordInfo { get; set; }
		public virtual DbSet<RecordStatusLog> RecordStatusLog { get; set; }
		public virtual DbSet<SessionInfo> SessionInfo { get; set; }
		public virtual DbSet<StatusDefinition> StatusDefinition { get; set; }

		public virtual DbSet<T> GetDbSet<T>() where T : class
		{
			return Set<T>();
		}

		public BmtContext(DbContextOptions<BmtContext> options)
			: base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var loggerFactory = new LoggerFactory();
			loggerFactory.AddProvider(new DebugLoggerProvider());
			optionsBuilder.UseLoggerFactory(loggerFactory);
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ImportLog>(entity =>
			{
				entity.HasKey(e => new { SiSessionId = e.SessionID, IlItemId = e.ItemID });

				entity.Property(e => e.AdditionalInfo1).IsUnicode(false);

				entity.Property(e => e.AdditionalInfo2).IsUnicode(false);

				entity.Property(e => e.IL_ProcessingPhase).HasDefaultValueSql("((0))");

				entity.Property(e => e.LogMessage).IsUnicode(false);

				entity.Property(e => e.ObjectID).IsUnicode(false);

				entity.Property(e => e.TimeStamp).HasDefaultValueSql("(getutcdate())");
			});

			modelBuilder.Entity<InterfaceInfo>(entity =>
			{
				entity.HasIndex(e => e.IntID)
					.HasName("ByIntID")
					.IsUnique();

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.II_Direction).IsUnicode(false);

				entity.Property(e => e.AdditionalInfo1Label).IsUnicode(false);

				entity.Property(e => e.AdditionalInfo2Label).IsUnicode(false);

				entity.Property(e => e.IntID).IsUnicode(false);

				entity.Property(e => e.LastInstallation).HasDefaultValueSql("(getutcdate())");

				entity.Property(e => e.Name).IsUnicode(false);

				entity.Property(e => e.ObjectIDLabel)
					.IsUnicode(false)
					.HasDefaultValueSql("('ObjectId')");

				entity.Property(e => e.Version).IsUnicode(false);
			});

			modelBuilder.Entity<ObjectMetadata>(entity =>
			{
				entity.HasKey(e => new { SiSessionId = e.SessionID, OmtdId = e.ID });

				entity.HasIndex(e => new { SiSessionId = e.SessionID, OmtdId = e.ID, OmtddId = e.ObjectMetadataDefinitionID })
					.HasName("ByMetadataDef");

				entity.HasIndex(e => new { SiSessionId = e.SessionID, OmtdId = e.ID, OmtddValue = e.Value })
					.HasName("ByValue");

				entity.Property(e => e.ObjectID).IsUnicode(false);

				entity.Property(e => e.Value).IsUnicode(false);
			});

			modelBuilder.Entity<ObjectMetadataDefinition>(entity =>
			{
				entity.HasIndex(e => new { OmtddId = e.ID, IiId = e.InterfaceInfoID })
					.HasName("ByIntfInfoID");

				entity.Property(e => e.Label).IsUnicode(false);
			});

			modelBuilder.Entity<SessionInfo>(entity =>
			{
				entity.Property(e => e.FileName).IsUnicode(false);

				entity.Property(e => e.ImportMode).IsUnicode(false);

				entity.Property(e => e.JobID).IsUnicode(false);

				entity.Property(e => e.ObjectType).IsUnicode(false);

				entity.Property(e => e.SI_VerboseLevel).HasDefaultValueSql("((5))");

				entity.Property(e => e.StorageFileName).IsUnicode(false);
			});

			modelBuilder.Entity<ProcessedObject>(entity =>
			{
				entity.HasKey(e => new { SiSessionId = e.SessionID, RiRecordId = e.RecordID, PoObjectId = e.ObjectID });

				entity.Property(e => e.RecordID).IsUnicode(false);

				entity.Property(e => e.ObjectID).IsUnicode(false);
			});

			modelBuilder.Entity<RecordInfo>(entity =>
			{
				entity.HasKey(e => new { RiRecordId = e.RecordID, SiSessionId = e.SessionID });

				entity.Property(e => e.RecordID).IsUnicode(false);

				entity.Property(e => e.StorageFileName).IsUnicode(false);
			});

			modelBuilder.Entity<RecordStatusLog>(entity =>
			{
				entity.HasKey(e => new { RiRecordId = e.RecordID, SiSessionId = e.SessionID, RslId = e.RecordStatusLogID });

				entity.Property(e => e.RecordID).IsUnicode(false);
			});
		}
	}
}
