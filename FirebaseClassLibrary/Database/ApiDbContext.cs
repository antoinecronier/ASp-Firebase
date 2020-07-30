using FirebaseClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseClassLibrary.Database
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public ApiDbContext() : base("default")
        {
            if (this.Database.CreateIfNotExists())
            {
                List<EquipmentType> equipmentTypes = new List<EquipmentType>();
                List<CarType> carTypes = new List<CarType>();
                List<Car> cars = new List<Car>();
                List<Role> roles = new List<Role>();
                List<User> users = new List<User>();

                var eqt1 = new EquipmentType() { Id = 1, Name = "Portière passagé" };
                var eqt2 = new EquipmentType() { Id = 2, Name = "Portière conducteur" };
                var eqt3 = new EquipmentType() { Id = 3, Name = "Portière arrière passagé" };
                var eqt4 = new EquipmentType() { Id = 4, Name = "Portière arrière conducteur" };
                var eqt5 = new EquipmentType() { Id = 5, Name = "Capot" };
                var eqt6 = new EquipmentType() { Id = 6, Name = "Coffre" };
                var eqt7 = new EquipmentType() { Id = 7, Name = "Roue" };
                var eqt8 = new EquipmentType() { Id = 8, Name = "Réservoire" };

                equipmentTypes.Add(eqt1);
                equipmentTypes.Add(eqt2);
                equipmentTypes.Add(eqt3);
                equipmentTypes.Add(eqt4);
                equipmentTypes.Add(eqt5);
                equipmentTypes.Add(eqt6);
                equipmentTypes.Add(eqt7);
                equipmentTypes.Add(eqt8);

                var r1 = new Role() { Id = 1, Name = "Automobiliste" };
                var r2 = new Role() { Id = 2, Name = "Garagiste" };
                var r3 = new Role() { Id = 3, Name = "Passagé" };
                var r4 = new Role() { Id = 4, Name = "Controlleur" };

                roles.Add(r1);
                roles.Add(r2);
                roles.Add(r3);
                roles.Add(r4);

                var cT1 = new CarType()
                {
                    Id = 1,
                    Name = "voiture 1",
                    EquipmentTypes = new List<EquipmentType>()
                {
                    eqt1,
                    eqt2,
                    eqt3,
                    eqt4,
                    eqt5,
                    eqt6,
                    eqt7,
                    eqt8,
                }
                };

                var cT2 = new CarType()
                {
                    Id = 2,
                    Name = "voiture 2",
                    EquipmentTypes = new List<EquipmentType>()
                {
                    eqt5,
                    eqt6,
                    eqt7,
                    eqt8,
                }
                };

                var cT3 = new CarType()
                {
                    Id = 3,
                    Name = "voiture 3",
                    EquipmentTypes = new List<EquipmentType>()
                {
                    eqt1,
                    eqt2,
                    eqt3,
                    eqt4,
                    eqt5,
                    eqt6,
                    eqt7,
                    eqt8,
                    eqt8,
                }
                };

                var cT4 = new CarType()
                {
                    Id = 4,
                    Name = "voiture 4",
                    EquipmentTypes = new List<EquipmentType>()
                {
                    eqt1,
                    eqt2,
                    eqt3,
                    eqt4,
                    eqt5,
                    eqt6,
                    eqt6,
                    eqt7,
                    eqt8,
                    eqt8,
                    eqt8,
                }
                };

                carTypes.Add(cT1);
                carTypes.Add(cT2);
                carTypes.Add(cT3);
                carTypes.Add(cT4);

                var c1 = new Car() { Id = 1, Mileage = 10500, Registration = "AM-236-CV", Type = cT1 };
                var c2 = new Car() { Id = 2, Mileage = 8500, Registration = "AZ-226-CD", Type = cT1 };
                var c3 = new Car() { Id = 3, Mileage = 100500, Registration = "BM-136-BV", Type = cT1 };
                var c4 = new Car() { Id = 4, Mileage = 99632, Registration = "AM-231-ZZ", Type = cT2 };
                var c5 = new Car() { Id = 5, Mileage = 123456, Registration = "AR-856-VB", Type = cT2 };
                var c6 = new Car() { Id = 6, Mileage = 64318, Registration = "ZV-222-MM", Type = cT3 };
                var c7 = new Car() { Id = 7, Mileage = 456321, Registration = "RD-654-MD", Type = cT4 };
                var c8 = new Car() { Id = 8, Mileage = 111, Registration = "ZH-482-ZR", Type = cT4 };
                var c9 = new Car() { Id = 9, Mileage = 20020, Registration = "KP-336-ML", Type = cT4 };

                cars.Add(c1);
                cars.Add(c2);
                cars.Add(c3);
                cars.Add(c4);
                cars.Add(c5);
                cars.Add(c6);
                cars.Add(c7);
                cars.Add(c8);
                cars.Add(c9);

                var u1 = new User() { Id = 1, Firstname = "Jean", Lastname = "Dupond", Cars = new List<Car>() { c1 }, Roles = new List<Role>() { r1 } };
                var u2 = new User() { Id = 2, Firstname = "Yves", Lastname = "Martin", Cars = new List<Car>() { c2, c3 }, Roles = new List<Role>() { r1 } };
                var u3 = new User() { Id = 3, Firstname = "Raoul", Lastname = "Dupont", Cars = new List<Car>() { c2 }, Roles = new List<Role>() { r1 } };
                var u4 = new User() { Id = 4, Firstname = "Emet", Lastname = "Dupond", Cars = new List<Car>() { c4 }, Roles = new List<Role>() { r1 } };
                var u5 = new User() { Id = 5, Firstname = "Miriam", Lastname = "Higgins", Cars = new List<Car>() { c5 }, Roles = new List<Role>() { r1 } };
                var u6 = new User() { Id = 6, Firstname = "Jeanne", Lastname = "Black", Cars = new List<Car>() { c6, c7 }, Roles = new List<Role>() { r1 } };
                var u7 = new User() { Id = 7, Firstname = "Emeline", Lastname = "Green", Cars = new List<Car>() { c7, c8, c9 }, Roles = new List<Role>() { r2 } };
                var u8 = new User() { Id = 8, Firstname = "Milene", Lastname = "Strong", Cars = new List<Car>() { c1 }, Roles = new List<Role>() { r3 } };
                var u9 = new User() { Id = 9, Firstname = "Eva", Lastname = "Strong", Cars = new List<Car>() { c1 }, Roles = new List<Role>() { r3 } };
                var u10 = new User() { Id = 10, Firstname = "Achile", Lastname = "Guidon", Cars = new List<Car>() { c1 }, Roles = new List<Role>() { r3 } };
                var u11 = new User() { Id = 11, Firstname = "Paul", Lastname = "RAS", Cars = new List<Car>() { c1 }, Roles = new List<Role>() { r3 } };
                var u12 = new User() { Id = 12, Firstname = "Ivan", Lastname = "Martin", Cars = new List<Car>() { c2 }, Roles = new List<Role>() { r3 } };
                var u13 = new User() { Id = 13, Firstname = "Iffes", Lastname = "Blandin", Cars = new List<Car>() { c1, c2, c3, c4 }, Roles = new List<Role>() { r4 } };
                var u14 = new User() { Id = 14, Firstname = "Ive", Lastname = "Ive", Cars = new List<Car>() { c6, c7, c8 }, Roles = new List<Role>() { r4 } };

                users.Add(u1);
                users.Add(u2);
                users.Add(u3);
                users.Add(u4);
                users.Add(u5);
                users.Add(u6);
                users.Add(u7);
                users.Add(u8);
                users.Add(u9);
                users.Add(u10);
                users.Add(u11);
                users.Add(u12);
                users.Add(u13);
                users.Add(u14);

                this.Roles.AddRange(roles);
                this.SaveChanges();
                this.EquipmentTypes.AddRange(equipmentTypes);
                this.SaveChanges();
                this.CarTypes.AddRange(carTypes);
                this.SaveChanges();
                this.Cars.AddRange(cars);
                this.SaveChanges();
                this.Users.AddRange(users);
                this.SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.Cars).WithMany();
            modelBuilder.Entity<User>().HasMany(x => x.Roles).WithMany();
            modelBuilder.Entity<Car>().HasRequired(x => x.Type).WithMany();
            modelBuilder.Entity<CarType>().HasMany(x => x.EquipmentTypes).WithMany();
        }
    }
}
