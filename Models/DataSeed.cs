using MavelArtist.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Models
{
    public class DataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ArtistContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ArtistContext>>()))
            {
                Artist artist1 = new Artist()
                {
                    Name = "Robert John Downey Jr",
                    DayOfBirth = DateTime.Parse("1965-4-4"),
                    Education= "Santa Monica High School",
                    Hometown="New York"
                };

                Artist artist2 = new Artist()
                {
                    Name = "Christopher Robert Evans",
                    DayOfBirth = DateTime.Parse("1981-6-13"),
                    Education = "Unknown",
                    Hometown = "Boston,Massachusetts,US"
                };

                Artist artist3 = new Artist()
                {
                    Name = "Elizabeth Chase Olsen",
                    DayOfBirth = DateTime.Parse("1989-2-16"),
                    Education = "New York University",
                    Hometown = "Los Angeles,California,US"
                };


                //----------------------------------------------------

                MavelCharacter character1 = new MavelCharacter()
                {
                    Name= "Tony stark",
                    HeroName="Iron man",
                    Power="Smart,Rich,Iron man suit",
                    Artist=artist1
                };

                MavelCharacter character2 = new MavelCharacter()
                {
                    Name = "Steven Rogers",
                    HeroName = "Captain America",
                    Power = "Sodier and Shield",
                    Artist=artist2
                };

                MavelCharacter character3 = new MavelCharacter()
                {
                    Name = "Wanda Maximoff",
                    HeroName = "Scarlet Witch",
                    Power = "Mind Stone",
                    Artist=artist3
                };

                //-----------------------------------------------------------

                List<Movies> movies = new List<Movies>()
                {
                    new Movies()
                    {
                        Name="Sherlock Holmes",
                        ReleaseYear=2011,
                        Role="Sherlock Holmes",
                        Artist=artist1
                    },
                    new Movies()
                    {
                        Name="Game 6",
                        ReleaseYear=2005,
                        Role="Steven Schwimmer",
                        Artist=artist1
                    },
                    new Movies()
                    {
                        Name="The Judge",
                        ReleaseYear=2014,
                        Role="Hank Palmer",
                        Artist=artist1
                    }
                    //--------------------------------

                    ,
                    new Movies()
                    {
                        Name="Fantastic Four",
                        ReleaseYear=2005,
                        Role="Johnny Storm",
                        Artist=artist2
                    },
                    new Movies()
                    {
                        Name="Scott Pilgrim vs the World",
                        ReleaseYear=2010,
                        Role="Lucas Lee",
                        Artist=artist2
                    },
                    new Movies()
                    {
                        Name="Cellular",
                        ReleaseYear=2004,
                        Role="Ryan",
                        Artist=artist2
                    }

                    //-----------------------------------

                    ,
                    new Movies()
                    {
                        Name="Silent House",
                        ReleaseYear=2011,
                        Role="Sarah",
                        Artist=artist3
                    },
                    new Movies()
                    {
                        Name="Very Good Girls",
                        ReleaseYear=2013,
                        Role="Gerry Fields",
                        Artist=artist3
                    },
                    new Movies()
                    {
                        Name="Oldboy",
                        ReleaseYear=2014,
                        Role="Marie Sebastian",
                        Artist=artist3
                    }
                };

                context.Artists.Add(artist1);
                context.Artists.Add(artist2);
                context.Artists.Add(artist3);


                context.MavelCharacters.Add(character1);
                context.MavelCharacters.Add(character2);
                context.MavelCharacters.Add(character3);


                foreach (var item in movies)
                {
                    context.Movies.Add(item);
                }

                context.SaveChanges();


            }
        }
    }
}
