﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Raisins.Client.Web.Models
{
    public class Beneficiary
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public static List<Beneficiary> GetAll()
        {
            using (var db = ObjectProvider.CreateDB())
            {
                return db.Beneficiaries.ToList();
            }
        }

        public static Beneficiary Find(int id = 0)
        {
            using (var db = ObjectProvider.CreateDB())
            {
                return db.Beneficiaries.Find(id);
            }
        }

        public static Beneficiary Add(Beneficiary beneficiary)
        {
            using (var db = ObjectProvider.CreateDB())
            {
                db.Beneficiaries.Add(beneficiary);
                db.SaveChanges();

                return beneficiary;
            }
        }

        public static Beneficiary Edit(Beneficiary beneficiary)
        {
            using (var db = ObjectProvider.CreateDB())
            {
                db.Entry(beneficiary).State = EntityState.Modified;
                db.SaveChanges();

                return beneficiary;
            }
        }

        public static void Delete(int id)
        {
            using (var db = ObjectProvider.CreateDB())
            {
                var Beneficiary = Find(id);

                db.Beneficiaries.Remove(Beneficiary);
                db.SaveChanges();
            }
        }

    }
}