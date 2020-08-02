﻿using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvidentInstruction.Generator.Models
{
    public class BogusProvider : IBogusProvider
    {
        private readonly Faker faker;

        public BogusProvider(string locale)
        {
            this.faker = new Faker(locale);
        }
        public string Guid()
        {
            return faker.Random.Guid().ToString();
        }
        public DateTime Between(DateTime? start = null, DateTime? end = null)
        {
            start = start ?? Constants.startDate;
            end = end ?? Constants.endDate;
            return faker.Date.Between((DateTime)start, (DateTime)end);
        }
        public int IntNumbers(int len)
        {
            return faker.Random.Int((int)Math.Pow(10, len - 1), (int)Math.Pow(10, len) - 1);
        }
        public double DoubleNumbers(int len, int limit)
        {
            var number = faker.Random.Double(Math.Pow(10, len - 1), Math.Pow(10, len) - 1);
            return Math.Round(number, limit);
        }
        //в формате  (###)###-####
        public string Phone(string format = "(###)###-####")
        {
            return faker.Phone.PhoneNumber(format);
        }
        public virtual string String(int len)
        {
            return faker.Random.String2(len, Constants.chars + Constants.digits);
        }
        public virtual string RuString(int len)
        {
            return faker.Random.String2(len, Constants.ruChars + Constants.digits);
        }
        public virtual string Chars(int len)
        {
            return faker.Random.String2(len, Constants.chars);
        }
        public virtual string RuChars(int len)
        {
            return faker.Random.String2(len, Constants.ruChars);
        }

        public int IntFromTo(int min, int max)
        {
            return faker.Random.Int(min, max);
        }

        public double DoubleFromTo(double min, double max, int limit)
        {
            var number = faker.Random.Double(min, max);
            return Math.Round(number, limit);
        }

        public string Month()
        {
            return faker.Date.Month();
        }

        public string Weekday()
        {
            return faker.Date.Weekday();
        }

        public string Email(string domen)
        {
            return faker.Internet.Email(provider: domen);
        }

        public string Ip()
        {
            return faker.Internet.Ip();
        }

        public string Url()
        {
            return faker.Internet.Url();
        }

        public string Sentence(int count)
        {
            return faker.Lorem.Sentence(count);
        }

        public string Paragraph(int min)
        {
            return faker.Lorem.Paragraph(min);
        }

        public string FirstName()
        {
            return faker.Name.FirstName();
        }

        public string LastName()
        {
            return faker.Name.LastName();
        }

        public string FullName()
        {
            return faker.Name.FullName();
        }
    }
}
