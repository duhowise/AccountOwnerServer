using System;
using Entities.Models;

namespace Entities.Extensions
{
    public static class OwnerExtensions
    {
        public static void Map(this Owner dbOwner, Owner owner)
        {
            if (!string.IsNullOrWhiteSpace(owner.Name)) dbOwner.Name = owner.Name;
            if (!string.IsNullOrWhiteSpace(owner.Address)) dbOwner.Address = owner.Address;
            if (owner.DateOfBirth !=DateTime.MinValue) dbOwner.DateOfBirth = owner.DateOfBirth;
           
        }
    }
}