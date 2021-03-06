﻿using System;

namespace Fitness.BL.Models
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get => (DateTime.Now - DateOfBirth).Days / 365; }
        #endregion
        

        public User()
        {

        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Incorrect name", nameof(name));
            }
            Name = name;
        }

        public User(string name,
                    Gender gender,
                    DateTime dateOfBirth,
                    double weight,
                    double height) : this(name)
        {

            if (dateOfBirth.Year < 1900)
            {
                throw new ArgumentException("Wrong date of birth", nameof(dateOfBirth));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Wrong weight", nameof(weight));

            }

            if (height <= 0)
            {
                throw new ArgumentException("Wrong height", nameof(height));

            }

            Gender = gender;
            DateOfBirth = dateOfBirth;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return $"{Name}, {Gender} ({Age}).\n Weight->{Weight}\tHeight->{Height}";
        }


    }
}
