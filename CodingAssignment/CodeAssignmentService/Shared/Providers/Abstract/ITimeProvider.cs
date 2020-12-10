using Microsoft.TeamFoundation.Framework.Common;
using System;

namespace CodeAssignmentService.Shared.Providers.Abstract
{
    public interface ITimeProvider
    {
        DateTime GetToday();
    }

    public class TimeProvider : ITimeProvider
    {
        public DateTime GetToday()
        {
            return DateTime.Today;
        }


    }
}