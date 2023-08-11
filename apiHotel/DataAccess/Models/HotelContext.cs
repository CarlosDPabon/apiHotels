using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingPerson> BookingPeople { get; set; }

    public virtual DbSet<ContactEmergency> ContactEmergencies { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelUser> HotelUsers { get; set; }

    public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolModule> RolModules { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomTax> RoomTaxes { get; set; }

    public virtual DbSet<Tax> Taxes { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserInfoRol> UserInfoRols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__C6D03BCDFED9ACE5");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("bookingId");
            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("checkIn");
            entity.Property(e => e.CheckOut)
                .HasColumnType("datetime")
                .HasColumnName("checkOut");
            entity.Property(e => e.ContactEmergencyId).HasColumnName("contactEmergencyId");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.RoomId).HasColumnName("roomId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ContactEmergency).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ContactEmergencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Booking_contactEmergency");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Booking_Hotel");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Booking_Room");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Booking_User");
        });

        modelBuilder.Entity<BookingPerson>(entity =>
        {
            entity.HasKey(e => e.RelationId).HasName("PK__Booking___F0BD8F27403E764A");

            entity.ToTable("Booking_Person");

            entity.Property(e => e.RelationId).HasColumnName("relationId");
            entity.Property(e => e.BookingId).HasColumnName("bookingId");
            entity.Property(e => e.PersonId).HasColumnName("personId");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingPeople)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Booking_Person_Booking");

            entity.HasOne(d => d.Person).WithMany(p => p.BookingPeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Booking_Person_Person");
        });

        modelBuilder.Entity<ContactEmergency>(entity =>
        {
            entity.HasKey(e => e.ContactEmergencyId).HasName("PK__contactE__A078AC77650BBDEC");

            entity.ToTable("contactEmergency");

            entity.Property(e => e.ContactEmergencyId).HasColumnName("contactEmergencyId");
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.ContactEmergencies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contactEmergency_userInfo");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotel__17ADC472B0AB0C29");

            entity.ToTable("Hotel");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Hotel__4849DA0116B4F276").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Hotel__AB6E61649875B269").IsUnique();

            entity.HasIndex(e => e.NumberIdentification, "UQ__Hotel__F71B6BF626EA8F47").IsUnique();

            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HotelName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("hotelName");
            entity.Property(e => e.IdentificationId).HasColumnName("identificationId");
            entity.Property(e => e.NumberIdentification).HasColumnName("numberIdentification");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Ubication)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ubication");

            entity.HasOne(d => d.Identification).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.IdentificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Hotel_IdentificationType");
        });

        modelBuilder.Entity<HotelUser>(entity =>
        {
            entity.HasKey(e => e.RelationId).HasName("PK__Hotel_Us__F0BD8F275B671FA3");

            entity.ToTable("Hotel_User");

            entity.Property(e => e.RelationId).HasColumnName("relationId");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelUsers)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Hotel_User_Hotel");

            entity.HasOne(d => d.User).WithMany(p => p.HotelUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Hotel_User_UserInfo");
        });

        modelBuilder.Entity<IdentificationType>(entity =>
        {
            entity.HasKey(e => e.IdentificationId).HasName("PK__Identifi__8E2AE6FA774FE64F");

            entity.ToTable("IdentificationType");

            entity.Property(e => e.IdentificationId).HasColumnName("identificationId");
            entity.Property(e => e.IdentificationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("identificationName");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Module__8EEC8E176C0BEF45");

            entity.ToTable("Module");

            entity.HasIndex(e => e.Name, "UQ__Module__72E12F1B6C0E33D2").IsUnique();

            entity.Property(e => e.ModuleId).HasColumnName("moduleId");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__EC7D7D4D605D7724");

            entity.ToTable("Person");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Person__4849DA01E5EE5273").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Person__AB6E616498841F95").IsUnique();

            entity.HasIndex(e => e.NumberIdentification, "UQ__Person__F71B6BF6A537B66B").IsUnique();

            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birthDate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.IdentificationId).HasColumnName("identificationId");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.NumberIdentification).HasColumnName("numberIdentification");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

            entity.HasOne(d => d.Identification).WithMany(p => p.People)
                .HasForeignKey(d => d.IdentificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Person_IdentificationType");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__5402363487FA61E2");

            entity.ToTable("Rol");

            entity.Property(e => e.RolId).HasColumnName("rolId");
            entity.Property(e => e.RolName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("rolName");
        });

        modelBuilder.Entity<RolModule>(entity =>
        {
            entity.HasKey(e => e.Relation).HasName("PK__Rol_Modu__E959000F7228BD99");

            entity.ToTable("Rol_Module");

            entity.Property(e => e.Relation).HasColumnName("relation");
            entity.Property(e => e.ModuleId).HasColumnName("moduleId");
            entity.Property(e => e.RolId).HasColumnName("rolId");

            entity.HasOne(d => d.Module).WithMany(p => p.RolModules)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Rol_Module_Module");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolModules)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Rol_Module_Rol");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__6C3BF5BE0F1414D7");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId).HasColumnName("roomId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.NumberRoom).HasColumnName("numberRoom");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Type)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Ubication)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ubication");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Room_Hotel");
        });

        modelBuilder.Entity<RoomTax>(entity =>
        {
            entity.HasKey(e => e.RelationId).HasName("PK__Room_Tax__F0BD8F275D7B8B38");

            entity.ToTable("Room_Tax");

            entity.Property(e => e.RelationId).HasColumnName("relationId");
            entity.Property(e => e.TaxId).HasColumnName("TaxID");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomTaxes)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Room_Tax_Room");

            entity.HasOne(d => d.Tax).WithMany(p => p.RoomTaxes)
                .HasForeignKey(d => d.TaxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Room_Tax_Tax");
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.HasKey(e => e.TaxId).HasName("PK__Tax__24D288390579C789");

            entity.ToTable("Tax");

            entity.Property(e => e.TaxId).HasColumnName("taxId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__CB9A1CFF07C8B11E");

            entity.ToTable("UserInfo");

            entity.HasIndex(e => e.UserName, "UQ__UserInfo__66DCF95C0FF752A7").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("userName");

            entity.HasOne(d => d.Person).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserInfo_Person");
        });

        modelBuilder.Entity<UserInfoRol>(entity =>
        {
            entity.HasKey(e => e.RelationId).HasName("PK__UserInfo__F0BD8F27955F411A");

            entity.ToTable("UserInfo_Rol");

            entity.Property(e => e.RelationId).HasColumnName("relationId");
            entity.Property(e => e.RolId).HasColumnName("rolId");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
