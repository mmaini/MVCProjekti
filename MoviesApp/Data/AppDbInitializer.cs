using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Data.Static;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Kino 1",
                            Logo = "https://img.freepik.com/free-vector/retro-cinema-background_52683-1701.jpg?size=338&ext=jpg",
                            Description = "Ovo je opis prvog kina"
                        },
                        new Cinema()
                        {
                            Name = "Kino 2",
                            Logo = "https://img.freepik.com/free-vector/retro-cinema-background_52683-1701.jpg?size=338&ext=jpg",
                            Description = "Ovo je opis drugo kina"
                        },
                        new Cinema()
                        {
                            Name = "Kino 3",
                            Logo = "https://img.freepik.com/free-vector/retro-cinema-background_52683-1701.jpg?size=338&ext=jpg",
                            Description ="Ovo je opis trećeg kina"
                        },
                        new Cinema()
                        {
                            Name = "Kino 4",
                            Logo = "https://img.freepik.com/free-vector/retro-cinema-background_52683-1701.jpg?size=338&ext=jpg",
                            Description = "Ovo je opis četvrtog kina"
                        },
                        new Cinema()
                        {
                            Name = "Kino 5",
                            Logo = "https://img.freepik.com/free-vector/retro-cinema-background_52683-1701.jpg?size=338&ext=jpg",
                            Description = "Ovo je opis petog kina"
                        },
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
                            FullName = "Robert De Niro",
                            Bio = "Ovo je biografija prvog glumca",
                            ProfilePictureUrl = "https://pyxis.nymag.com/v1/imgs/5d2/3a6/60d7c8aa3cf100fd26e50ff697fc7fb779-28-midnight-run-robert-de-niro.2x.h473.w710.jpg"

                        },
                        new Actor()
                        {
                            FullName = "Al Pacino",
                            Bio = "Ovo je biografija drugog glumca",
                            ProfilePictureUrl = "https://svijetfilma.eu/wp-content/uploads/2019/04/06-al-pacino.w600.h315.2x.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Marlon Brando",
                            Bio =  "Ovo je biografija trećeg glumca",
                            ProfilePictureUrl = "https://www.jabuka.tv/wp-content/uploads/2020/04/marlond-brando-1.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Meryl Streep",
                            Bio =  "Ovo je biografija četvrtog glumca",
                            ProfilePictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Meryl_Streep_December_2018.jpg/220px-Meryl_Streep_December_2018.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Scarlett_Johansson",
                            Bio =  "Ovo je biografija petog glumca",
                            ProfilePictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/Scarlett_Johansson_in_Kuwait_01b.jpg/1200px-Scarlett_Johansson_in_Kuwait_01b.jpg"
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
                            FullName = "Francis Ford Coppola",
                            Bio = "Ovo je biografija prvog producenta",
                            ProfilePictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Francis_Ford_Coppola%28CannesPhotoCall%29.jpg/200px-Francis_Ford_Coppola%28CannesPhotoCall%29.jpg"

                        },
                        new Producer()
                        {
                            FullName = "Steven Spielberg",
                            Bio ="Ovo je biografija drugog producenta",
                            ProfilePictureUrl = "https://support.musicgateway.com/wp-content/uploads/2020/12/Copy-of-800-x-500-Blog-Post-1-4.png"
                        },
                        new Producer()
                        {
                            FullName = "Quentin Tarantino",
                            Bio ="Ovo je biografija trećeg producenta",
                            ProfilePictureUrl = "https://support.musicgateway.com/wp-content/uploads/2020/12/Copy-of-800-x-500-Blog-Post-3-4.png"
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
                            Name = "The Godfather",
                            Description = "Opis filma Kum",
                            Price = 39.50,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/hr/a/a2/Kum1.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "Opis filmy Shawshank Redemption description",
                            Price = 29.50,
                            ImageUrl = "https://m.media-amazon.com/images/I/51zUbui+gbL.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name = "It",
                            Description = "Opis filma It",
                            Price = 39.50,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BYjg1YTRkNzQtODgyYi00MTQ5LThiMDYtNDJjMWRjNTdjZDZlXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "March of the penguins",
                            Description = "Opis filma March of the penguins",
                            Price = 39.50,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTM1NDc5MDYxMl5BMl5BanBnXkFtZTcwMjMzNDAzMQ@@._V1_.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId =3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Ice age",
                            Description = "Opis filma Ice age",
                            Price = 39.50,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3c/Ice_Age_%282002_film%29_poster.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Titanic",
                            Description = "Opis filma Titanic",
                            Price = 39.50,
                            ImageUrl = "https://www.goldenglobes.com/sites/default/files/articles/cover_images/1998-titanic.jpg?format=pjpg&auto=webp&optimize=high&width=850",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.ActorsMovies.Any())
                {
                    context.ActorsMovies.AddRange(new List<ActorMovie>()
                    {
                        new ActorMovie()
                        {

                            ActorId = 1,
                            MovieId = 1
                        },
                        new ActorMovie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new ActorMovie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new ActorMovie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new ActorMovie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new ActorMovie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new ActorMovie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new ActorMovie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new ActorMovie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new ActorMovie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new ActorMovie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new ActorMovie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new ActorMovie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRoles(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRole.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));

                if (!await roleManager.RoleExistsAsync(UserRole.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.User));


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin Admin",
                        UserName = "admin",
                        Email = "admin@admin.com",
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(newAdminUser, "P@ssword123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRole.Admin);
                }


                var appUser = await userManager.FindByEmailAsync("user@user.com");
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "User User",
                        UserName = "user",
                        Email = "user@user.com",
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(newAppUser, "P@ssword123");
                    await userManager.AddToRoleAsync(newAppUser, UserRole.User);
                }

            }
        }

    }
    }

