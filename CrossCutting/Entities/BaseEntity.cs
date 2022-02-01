using CrossCutting.Helpers;
using System;

namespace CrossCutting.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public Guid UserAdd { get; set; }
        public DateTime DateAdd { get; set; }
        public Guid UserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }

        public static void AddDateTime(BaseEntity model)
        {
            model.DateAdd = DateTimeHelper.GetDateTime();
            model.DateUpdate = DateTimeHelper.GetDateTime();
        }

        public static void UpdateDateTime(BaseEntity model)
        {
            model.DateUpdate = DateTimeHelper.GetDateTime();
        }
    }
}
