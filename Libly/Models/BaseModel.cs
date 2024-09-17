﻿namespace Libly.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? ModifiedOn { get; set; }

        protected BaseModel()
        {
            CreatedOn = DateTime.Now;
        }      
    }
}
