using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Data
{
    public class DbInitializer
    {
        public static void Initialize(ParaglidingClubContext context)
        {
            context.Database.EnsureCreated();

            #region Pilots
            if (context.Pilots.Any())
            {
                return;
            }

            var pilots = new Pilot[]
            {
                new Pilot{FirstName="Tony", LastName="Stark", Adress="39 Cliffbide Drive Malibu, CA 56677", PhoneNumber="0488971525", Weight=78, IsActif=true, PostitionID=1 },
                new Pilot{FirstName="Steve", LastName="Rogers", Adress="1404 Alameda Ave Brooklyn, NY 11365", PhoneNumber="0456321598", Weight=99, IsActif=true, PostitionID=2 },
                new Pilot{FirstName="Clint", LastName="Barton", Adress="244 Ramblewood St. San Angelo, TX 76904", PhoneNumber="0423165878", Weight=80, IsActif=true, PostitionID=3 },
                new Pilot{FirstName="Bruce", LastName="Banner", Adress="273 South St Louis Lane New York, NY 10034", PhoneNumber="04598617", Weight=79, IsActif=true},
                new Pilot{FirstName="Natacha", LastName="Romanov", Adress="70 Arnold St. Los Angeles, CA 90042", PhoneNumber="04598617", Weight=55, IsActif=true },
            };

            foreach (Pilot p in pilots)
            {
                context.Pilots.Add(p);
            }
            context.SaveChanges();

            #endregion

            #region ModelParaglidings


            var models = new ModelParagliding[]
            {
                new ModelParagliding{HeightParagliding="25m²", MaxWeightPilot=90, MinWeightPilot=40, AprovalDate=DateTime.Parse("2015-03-15"), AprovalNumber="152689" },
                new ModelParagliding{HeightParagliding="26m²", MaxWeightPilot=100, MinWeightPilot=45, AprovalDate=DateTime.Parse("2012-07-28"), AprovalNumber="256986" },
                new ModelParagliding{HeightParagliding="28m²", MaxWeightPilot=120, MinWeightPilot=60, AprovalDate=DateTime.Parse("2017-01-04"), AprovalNumber="362514" },
            };

            foreach (ModelParagliding m in models)
            {
                context.ModelParaglidings.Add(m);
            }

            context.SaveChanges();
            #endregion

            #region Paraglidings

            var paraglidings = new Paragliding[]
            {
                new Paragliding{ModelParaglidingID=1, DateOfCommissioning=DateTime.Parse("2015-07-02"), DateOfLastRevision=DateTime.Parse("2019-12-09") },
                new Paragliding{ModelParaglidingID=1, DateOfCommissioning=DateTime.Parse("2016-01-28"), DateOfLastRevision=DateTime.Parse("2019-11-04") },
                new Paragliding{ModelParaglidingID=2, DateOfCommissioning=DateTime.Parse("2014-02-12"), DateOfLastRevision=DateTime.Parse("2020-01-10") },
                new Paragliding{ModelParaglidingID=2, DateOfCommissioning=DateTime.Parse("2013-08-03"), DateOfLastRevision=DateTime.Parse("2019-09-18") },
                new Paragliding{ModelParaglidingID=3, DateOfCommissioning=DateTime.Parse("2017-04-22"), DateOfLastRevision=DateTime.Parse("2019-11-25") },

            };

            foreach (Paragliding p in paraglidings)
            {
                context.Paraglidings.Add(p);
            }
            context.SaveChanges();

            #endregion

            #region Levels


            var levels = new Level[]
            {
                new Level{Name="Colibri", Skill="Savoir decoller, savoir atterrir", DifficultyNumber=1},
                new Level{Name="Mouette", Skill="Bonne maitrise du parapente, savoir évaluer les conditions météo", DifficultyNumber=2},
                new Level{Name="Aigle de bronze", Skill="Savoir enseigner aux aspirants pilotes, savoir voler avec treuil, très bonne maitrise", DifficultyNumber=3},
                new Level{Name="Aigle d'argent", Skill="Maitrise totale du parapente à tous temps", DifficultyNumber=4},
                new Level{Name="Aigle d'or", Skill="Savoir évaluer les aspirants pilotes et les moniteurs", DifficultyNumber=5},

            };

            foreach (Level l in levels)
            {
                context.Levels.Add(l);
            }

            context.SaveChanges();
            #endregion

            #region Licenses

            var licenses = new License[]
            {
                new License{Title="Pilote de parapente", LevelID=1},
                new License{Title="Pilote XC de parapente", LevelID=2},
                new License{Title="Moniteur de parapente", LevelID=3},
                new License{Title="Pilote au treuil de parapente", LevelID=4},
                new License{Title="Examinateur de parapente", LevelID=5}
            };

            foreach (License l in licenses)
            {
                context.Licenses.Add(l);
            }

            context.SaveChanges();

            #endregion

            #region Courses


            var courses = new Course[]
            {
                new Course{StartDate=DateTime.Parse("2018-04-29"), EndDate=DateTime.Parse("2018-05-30"), CoursePrice=70.00M, LicenseID=1},
                new Course{StartDate=DateTime.Parse("2018-06-18"), EndDate=DateTime.Parse("2018-07-10"), CoursePrice=30.50M, LicenseID=3},
                new Course{StartDate=DateTime.Parse("2018-09-15"), EndDate=DateTime.Parse("2018-11-12"), CoursePrice=46.00M, LicenseID=2},
                new Course{StartDate=DateTime.Parse("2019-01-15"), EndDate=DateTime.Parse("2019-03-20"), CoursePrice=60.00M, LicenseID=4},
                new Course{StartDate=DateTime.Parse("2019-05-25"), EndDate=DateTime.Parse("2019-07-19"), CoursePrice=35.80M, LicenseID=5},
                new Course{StartDate=DateTime.Parse("2019-10-02"), EndDate=DateTime.Parse("2019-12-23"), CoursePrice=30.50M, LicenseID=3}
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
            #endregion

            #region Sites


            var sites = new Site[]
            {
                new Site{Name="Boom", FlightType="Thermodynamiques", OrientationLanding="Est", AltitudeTakeOff=25, OrientationTakeOff="Sud", LevelID=1},
                new Site{Name="Ouren", FlightType="Thermodynamiques", OrientationLanding="Nord", OrientationTakeOff="Ouest", LevelID=3},
                new Site{Name="Hornu", FlightType="Termodynamiques", OrientationLanding="Sud", OrientationTakeOff="Est", LevelID=2},
            };

            foreach (Site s in sites)
            {
                context.Sites.Add(s);
            }

            context.SaveChanges();
            #endregion

            #region Subscriptions


            var subscriptions = new Subscription[]
            {
                new Subscription{YearID=2017, Price=20.00M},
                new Subscription{YearID=2018, Price=25.00M},
                new Subscription{YearID=2019, Price=15.50M},
                new Subscription{YearID=2020, Price=19.50M},

            };

            foreach (Subscription s in subscriptions)
            {
                context.Subscriptions.Add(s);
            }

            context.SaveChanges();
            #endregion

            #region Flights


            var flights = new Flight[]
            {
                new Flight{PilotID=1, ParaglidingID=2, FlightDate=DateTime.Parse("2018-04-18"), FlightStart=DateTime.Parse("2018-04-18 01:04:16"),  FlightEnd=DateTime.Parse("2018-04-18 01:09:55"), SiteID=2 },
                new Flight{PilotID=1, ParaglidingID=1, FlightDate=DateTime.Parse("2018-07-12"), FlightStart=DateTime.Parse("2018-07-12 01:04:16"),  FlightEnd=DateTime.Parse("2018-07-12 01:09:55"), SiteID=1 },
                new Flight{PilotID=1, ParaglidingID=2, FlightDate=DateTime.Parse("2019-04-04"), FlightStart=DateTime.Parse("2019-04-04 01:04:16"),  FlightEnd=DateTime.Parse("2019-04-04 01:09:55"), SiteID=1},
                new Flight{PilotID=1, ParaglidingID=2, FlightDate=DateTime.Parse("2019-07-21"),  FlightStart=DateTime.Parse("2019-07-21 01:04:16"),  FlightEnd=DateTime.Parse("2019-07-21 01:09:55"), SiteID=3 },
                new Flight{PilotID=2, ParaglidingID=5, FlightDate=DateTime.Parse("2018-01-21"), FlightStart=DateTime.Parse("2018-01-21 02:10:14"),  FlightEnd=DateTime.Parse("2019-07-21 02:14:45"), SiteID=1},
                new Flight{PilotID=2, ParaglidingID=5, FlightDate=DateTime.Parse("2019-04-21"), FlightStart=DateTime.Parse("2019-04-21 02:10:14"),  FlightEnd=DateTime.Parse("2019-04-21 02:14:45"), SiteID=1},
                new Flight{PilotID=2, ParaglidingID=5, FlightDate=DateTime.Parse("2018-08-21"), FlightStart=DateTime.Parse("2019-08-21 02:10:14"),  FlightEnd=DateTime.Parse("2019-08-21 02:14:45"), SiteID=1},
                new Flight{PilotID=2, ParaglidingID=5, FlightDate=DateTime.Parse("2019-09-21"), FlightStart=DateTime.Parse("2019-09-21 02:10:14"),  FlightEnd=DateTime.Parse("2019-09-21 02:14:45"), SiteID=1},
                new Flight{PilotID=3, ParaglidingID=2, FlightDate=DateTime.Parse("2018-04-18"), FlightStart=DateTime.Parse("2018-04-18 03:04:16"),  FlightEnd=DateTime.Parse("2018-04-18 03:09:55"), SiteID=3 },
                new Flight{PilotID=3, ParaglidingID=2, FlightDate=DateTime.Parse("2018-07-12"), FlightStart=DateTime.Parse("2018-07-12 03:04:16"),  FlightEnd=DateTime.Parse("2018-07-12 03:09:55"), SiteID=2 },
                new Flight{PilotID=3, ParaglidingID=3, FlightDate=DateTime.Parse("2019-04-04"), FlightStart=DateTime.Parse("2019-04-04 03:04:16"),  FlightEnd=DateTime.Parse("2019-04-04 03:09:55"), SiteID=1},
                new Flight{PilotID=3, ParaglidingID=2, FlightDate=DateTime.Parse("2019-07-21"),  FlightStart=DateTime.Parse("2019-07-21 03:04:16"),  FlightEnd=DateTime.Parse("2019-07-21 03:09:55"), SiteID=3 },
                new Flight{PilotID=4, ParaglidingID=4, FlightDate=DateTime.Parse("2018-04-18"), FlightStart=DateTime.Parse("2018-04-18 05:04:16"),  FlightEnd=DateTime.Parse("2018-04-18 05:09:55"), SiteID=3 },
                new Flight{PilotID=4, ParaglidingID=2, FlightDate=DateTime.Parse("2018-07-12"), FlightStart=DateTime.Parse("2018-07-12 05:04:16"),  FlightEnd=DateTime.Parse("2018-07-12 05:09:55"), SiteID=1 },
                new Flight{PilotID=4, ParaglidingID=1, FlightDate=DateTime.Parse("2019-04-04"), FlightStart=DateTime.Parse("2019-04-04 05:04:16"),  FlightEnd=DateTime.Parse("2019-04-04 05:09:55"), SiteID=1},
                new Flight{PilotID=4, ParaglidingID=2, FlightDate=DateTime.Parse("2019-07-21"),  FlightStart=DateTime.Parse("2019-07-21 05:04:16"),  FlightEnd=DateTime.Parse("2019-07-21 05:09:55"), SiteID=3 },
                new Flight{PilotID=5, ParaglidingID=1, FlightDate=DateTime.Parse("2018-04-18"), FlightStart=DateTime.Parse("2018-04-18 08:04:16"),  FlightEnd=DateTime.Parse("2018-04-18 08:09:55"), SiteID=1 },
                new Flight{PilotID=5, ParaglidingID=2, FlightDate=DateTime.Parse("2018-07-12"), FlightStart=DateTime.Parse("2018-07-12 08:04:16"),  FlightEnd=DateTime.Parse("2018-07-12 08:09:55"), SiteID=1 },
                new Flight{PilotID=5, ParaglidingID=1, FlightDate=DateTime.Parse("2019-04-04"), FlightStart=DateTime.Parse("2019-04-04 08:04:16"),  FlightEnd=DateTime.Parse("2019-04-04 08:09:55"), SiteID=1},
                new Flight{PilotID=5, ParaglidingID=2, FlightDate=DateTime.Parse("2019-07-21"),  FlightStart=DateTime.Parse("2019-07-21 08:04:16"),  FlightEnd=DateTime.Parse("2019-07-21 08:09:55"), SiteID=1 }
            };

            foreach (Flight f in flights)
            {
                context.Flights.Add(f);
            }
            context.SaveChanges();
            #endregion

            #region Payments


            var payments = new Payment[]
            {
                new Payment{SubsciptionID=1, PilotID=1, IsPay=true, DatePay=DateTime.Parse("2017-04-02")},
                new Payment{SubsciptionID=2, PilotID=1, IsPay=true, DatePay=DateTime.Parse("2018-04-02")},
                new Payment{SubsciptionID=3, PilotID=1, IsPay=true, DatePay=DateTime.Parse("2019-04-02")},
                new Payment{SubsciptionID=4, PilotID=1, IsPay=true, DatePay=DateTime.Parse("2020-01-02")},
                new Payment{SubsciptionID=1, PilotID=2, IsPay=true, DatePay=DateTime.Parse("2017-03-15")},
                new Payment{SubsciptionID=2, PilotID=2, IsPay=true, DatePay=DateTime.Parse("2018-06-02")},
                new Payment{SubsciptionID=3, PilotID=2, IsPay=true, DatePay=DateTime.Parse("2019-03-12")},
                new Payment{SubsciptionID=4, PilotID=2, IsPay=false},
                new Payment{SubsciptionID=2, PilotID=3, IsPay=true, DatePay=DateTime.Parse("2018-02-02")},
                new Payment{SubsciptionID=3, PilotID=3, IsPay=true, DatePay=DateTime.Parse("2019-01-22")},
                new Payment{SubsciptionID=4, PilotID=3, IsPay=true, DatePay=DateTime.Parse("2020-01-25")},
                new Payment{SubsciptionID=1, PilotID=4, IsPay=true, DatePay=DateTime.Parse("2017-04-12")},
                new Payment{SubsciptionID=2, PilotID=4, IsPay=true, DatePay=DateTime.Parse("2018-02-25")},
                new Payment{SubsciptionID=3, PilotID=4, IsPay=true, DatePay=DateTime.Parse("2019-01-14")},
                new Payment{SubsciptionID=4, PilotID=4, IsPay=true, DatePay=DateTime.Parse("2020-01-19")},
                new Payment{SubsciptionID=1, PilotID=5, IsPay=true, DatePay=DateTime.Parse("2017-01-23")},
                new Payment{SubsciptionID=2, PilotID=5, IsPay=true, DatePay=DateTime.Parse("2018-04-02")},
                new Payment{SubsciptionID=3, PilotID=5, IsPay=true, DatePay=DateTime.Parse("2019-04-28")},
                new Payment{SubsciptionID=3, PilotID=5, IsPay=false},
            };

            foreach (Payment p in payments)
            {
                context.Payments.Add(p);
            }

            context.SaveChanges();
            #endregion

            #region Obtainings


            var obtainings = new Obtaining[]
            {
                new Obtaining{PilotID=1, LicenseID=5, IsSucced=true, ObtainingDate=DateTime.Parse("2019-07-19") },
                new Obtaining{PilotID=2, LicenseID=1, IsSucced=true, ObtainingDate=DateTime.Parse("2018-05-30") },
                new Obtaining{PilotID=3, LicenseID=3, IsSucced=true, ObtainingDate=DateTime.Parse("2018-07-10") },
                new Obtaining{PilotID=3, LicenseID=4, IsSucced=false },
                new Obtaining{PilotID=4, LicenseID=1, IsSucced=true, ObtainingDate=DateTime.Parse("2018-05-30") },
                new Obtaining{PilotID=4, LicenseID=2, IsSucced=true, ObtainingDate=DateTime.Parse("2018-11-12") },
                new Obtaining{PilotID=5, LicenseID=1, IsSucced=true, ObtainingDate=DateTime.Parse("2018-05-30") },
                new Obtaining{PilotID=5, LicenseID=2, IsSucced=true, ObtainingDate=DateTime.Parse("2018-11-12") },
                new Obtaining{PilotID=5, LicenseID=3, IsSucced=true, ObtainingDate=DateTime.Parse("2019-12-23") },
            };

            foreach (Obtaining o in obtainings)
            {
                context.Obtainings.Add(o);
            }

            context.SaveChanges();

            #endregion

            #region Teachings


            var teachings = new Teaching[]
            {
                new Teaching{PilotID=1, CourseID=1},
                new Teaching{PilotID=1, CourseID=2},
                new Teaching{PilotID=1, CourseID=3},
                new Teaching{PilotID=1, CourseID=4},
                new Teaching{PilotID=1, CourseID=6},
                new Teaching{PilotID=3, CourseID=3},
                new Teaching{PilotID=3, CourseID=6},
            };

            foreach (Teaching t in teachings)
            {
                context.Teachings.Add(t);
            }

            context.SaveChanges();

            #endregion

            #region Participations


            var participations = new Participation[]
            {
                new Participation{CourseID=1, PilotID=2, DateOfParticipation=DateTime.Parse("2018-04-02"),  IsPay=true},
                new Participation{CourseID=1, PilotID=4, DateOfParticipation=DateTime.Parse("2018-04-02"), IsPay=true},
                new Participation{CourseID=1, PilotID=5, DateOfParticipation=DateTime.Parse("2018-04-03"), IsPay=true},
                new Participation{CourseID=2, PilotID=3,  DateOfParticipation=DateTime.Parse("2018-05-25"), IsPay=true},
                new Participation{CourseID=3, PilotID=4,  DateOfParticipation=DateTime.Parse("2018-08-30"), IsPay=true},
                new Participation{CourseID=3, PilotID=5,  DateOfParticipation=DateTime.Parse("2018-09-02"), IsPay=true},
                new Participation{CourseID=4, PilotID=3,  DateOfParticipation=DateTime.Parse("2019-01-03"), IsPay=true},
                new Participation{CourseID=5, PilotID=1,  DateOfParticipation=DateTime.Parse("2019-05-02"), IsPay=true},
                new Participation{CourseID=6, PilotID=5,  DateOfParticipation=DateTime.Parse("2019-09-19"), IsPay=true},
            };

            foreach (Participation p in participations)
            {
                context.Participations.Add(p);
            }

            context.SaveChanges();

            #endregion

            #region Positions


            var positions = new Position[]
            {
                new Position{Name="Président", PilotID=1 },
                new Position{Name="Secrétaire", PilotID=2 },
                new Position{Name="Trésorier", PilotID=3 },
            };

            foreach (Position p in positions)
            {
                context.Positions.Add(p);
            }

            context.SaveChanges();

            #endregion
        }
    }
}
