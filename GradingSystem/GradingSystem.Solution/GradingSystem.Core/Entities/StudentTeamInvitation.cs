namespace GradingSystem.Core.Entities
{
    public class StudentTeamInvitation
    {
        public string Status { get; set; } = "Pending"; // Status of the invitation (Pending(Default), Accepted, Rejected)
        public DateTime SentDate { get; set; } = DateTime.Now;
        public DateTime? ResponseDate { get; set; } // Date when the invitation was accepted or rejected
        public bool IsInviterStudent { get; set; } // True if initiated by Student, False if by Team


        // Foreign Keys
        public int StudentId { get; set; }
        public int TeamId { get; set; }


        #region Navigation Properties
        public Student Student { get; set; }
        public Team Team { get; set; }
        #endregion
    }

}