﻿using GamingUniversityApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static GamingUniversityApp.Common.EntityValidationConstants.Course;

namespace GamingUniversityApp.Data.Configuration
{
	public class CourseConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			//Fluent API
			builder.HasKey(c=>c.Id);
			builder.Property(c=>c.CourseName).IsRequired().HasMaxLength(NameMaxLength);
			builder.Property(c=>c.Description).IsRequired().HasMaxLength(DescriptionMaxLength);
			builder.Property(c => c.Credits).IsRequired();

			builder.HasData(this.SeedCourses());
		}

		private List<Course> SeedCourses()
		{
			List<Course> courses = new List<Course>()
			{
				new Course()
				{
					CourseName = "League of Legends",
					Description = "League of Legends is a multiplayer online battle arena (MOBA) game in which the player controls a character (\"champion\") with a set of unique abilities from an isometric perspective. " +
					"As of 2024, there are 168 champions available to play. Over the course of a match, champions gain levels by accruing experience points (XP) through killing enemies. " +
					"Items can be acquired to increase champions' strength, and are bought with gold, which players accrue passively over time and earn actively by defeating the opposing team's minions, champions, or defensive structures. " +
					"In the main game mode, Summoner's Rift, items are purchased through a shop menu available to players only when their champion is in the team's base. Each match is discrete; levels and items do not transfer from one match to another.",
					Credits = 25
				},
				new Course()
				{
					CourseName = "Counter Strike",
					Description = "Counter-Strike is an objective-based, multiplayer tactical first-person shooter." +
					" Two opposing teams—the Terrorists and the Counter Terrorists—compete in game modes to complete objectives, such as securing a location to plant or defuse a bomb and rescuing or guarding hostages." +
					" At the end of each round, players are rewarded based on their individual performance with in-game currency to spend on more powerful weapons in subsequent rounds. " +
					"Winning rounds results in more money than losing and completing objectives such as killing enemy players gives cash bonuses.Uncooperative actions, such as killing teammates, result in a penalty.",
					Credits = 30
				}
			};

			return courses;
		}
	}
}
