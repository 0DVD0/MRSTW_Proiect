using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Interface
{
    public interface ICoachApi
    {
        void CreateCoach(string name, string surname, DateTime birthdate);
        void RemoveCoach(int coachId);
        Coach GetCoachById(int coachId);
        void UpdateCoach(int coachId, string name, string surname, DateTime birthdate);
        List<Coach> GetAll();
    }
}