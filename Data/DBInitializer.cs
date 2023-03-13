using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class DBInitializer
    {
        public static void Initialize(eTicketsDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();
           /* if (context.Actors.Any())
            {
                return;   // DB has been seeded
            }
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }
            if (context.Cenimas.Any())
            {
                return;   // DB has been seeded
            }
            if (context.Producers.Any())
            {
                return;   // DB has been seeded
            }
            if (context.Actors_Movies.Any())
            {
                return;   // DB has been seeded
            }*/
            //Cenimas

            if (!context.Cenimas.Any())
            {
                context.Cenimas.AddRange(new List<Cenima>()
                {
                    new Cenima()
                    {
                        CenimaName = "Atrium",
                        CenimaLogo = "C:\\Users\\mwasif\\source\\repos\\eTickets\\Images\\Atrium Logo.jpg",
                        Description = "Atrium Cinemas, 3rd Floor, Atrium Mall,\r\n249 Staff Lines, Zaibunnisa Street, Saddar, Karachi\r\n\r\nRecommended approach:\r\nTo reach the mall, enter from Raja Ghazanfar Ali Road, Behind Avari Towers"
                    },

                    new Cenima()
                    {
                        CenimaName = "Nuplex",
                        CenimaLogo = "C:\\Users\\mwasif\\source\\repos\\eTickets\\Images\\Nuplex-Logo.jpg",
                        Description = "Nueplex Cinemas Askari IV\r\nAddress: Rashid Minhas Road, Askari 4 - Karachi 75290\r\n\r\nPhone: (021) 111 683 683"
                    },
                    new Cenima()
                    {
                        CenimaName = "Mega Multiplex",
                        CenimaLogo = "C:\\Users\\mwasif\\source\\repos\\eTickets\\Images\\Mega Multiplex Logo.jpeg",
                        Description = " With the passion of giving the best , deriving innovation for your ease , inculcating the new trends to let you stay connected with everything happening around."
                    }
                });
                context.SaveChanges();

            }

            //Actors

            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            ActorName = "Actor 1",
                            bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            ActorName = "Actor 2",
                            bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            ActorName = "Actor 3",
                            bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            ActorName = "Actor 4",
                            bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            ActorName = "Actor 5",
                            bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                context.SaveChanges();
            }

            //Producers

            if (!context.Producers.Any())
            {
                context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            ProducerName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureName = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            ProducerName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureName = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            ProducerName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureName = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            ProducerName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureName = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            ProducerName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureName = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                context.SaveChanges();
            }

            //Movies

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            MovieName = "Life",
                            Description = "This is the Life movie description",
                            Price = 1000,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CenimaID = 27,
                            ProducerId = 43,
                            MovieCategory = Enums.Genre.Documentry
                        },
                        new Movie()
                        {
                            MovieName = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 1000,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CenimaID = 25,
                            ProducerId = 41,
                            MovieCategory = Enums.Genre.Action
                        },
                        new Movie()
                        {
                            MovieName = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 1000,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CenimaID = 28,
                            ProducerId = 44,
                            MovieCategory = Enums.Genre.Horror
                        },
                        new Movie()
                        {
                            MovieName = "Race",
                            Description = "This is the Race movie description",
                            Price = 1000,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CenimaID = 25,
                            ProducerId = 42,
                            MovieCategory = Enums.Genre.Documentry
                        },
                        new Movie()
                        {
                            MovieName = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 1000,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CenimaID = 25,
                            ProducerId = 43,
                            MovieCategory = Enums.Genre.Cartoon
                        },
                        new Movie()
                        {
                            MovieName = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 1000,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CenimaID = 25,
                            ProducerId = 45,
                            MovieCategory = Enums.Genre.Drama
                        }
                    });
                context.SaveChanges();
            }

            //ActorMovies

            //Actors & Movies
            if (!context.Actors_Movies.Any())
            {
                context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorID = 41,
                            MovieId = 48
                        },
                        new Actor_Movie()
                        {
                            ActorID = 43,
                            MovieId = 48
                        },

                         new Actor_Movie()
                        {
                            ActorID = 41,
                            MovieId = 49
                        },
                         new Actor_Movie()
                        {
                            ActorID = 44,
                            MovieId = 49
                        },

                        new Actor_Movie()
                        {
                            ActorID = 41,
                            MovieId = 50
                        },
                        new Actor_Movie()
                        {
                            ActorID = 42,
                            MovieId = 50
                        },
                        new Actor_Movie()
                        {
                            ActorID = 45,
                            MovieId = 50
                        },


                        new Actor_Movie()
                        {
                            ActorID = 42,
                            MovieId = 51
                        },
                        new Actor_Movie()
                        {
                            ActorID = 43,
                            MovieId = 51
                        },
                        new Actor_Movie()
                        {
                            ActorID = 44,
                            MovieId = 51
                        },


                        new Actor_Movie()
                        {
                            ActorID = 42,
                            MovieId = 52
                        },
                        new Actor_Movie()
                        {
                            ActorID = 43,
                            MovieId = 52
                        },
                        new Actor_Movie()
                        {
                            ActorID = 44,
                            MovieId = 52
                        },
                        new Actor_Movie()
                        {
                            ActorID = 45,
                            MovieId = 52
                        },


                        new Actor_Movie()
                        {
                            ActorID = 43,
                            MovieId = 53
                        },
                        new Actor_Movie()
                        {
                            ActorID = 44,
                            MovieId = 53
                        },
                        new Actor_Movie()
                        { 
                            ActorID = 45,
                            MovieId = 53
                        },
                    });
                context.SaveChanges();
            }
        }

    }



}
