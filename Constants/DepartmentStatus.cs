using NHNT.Constants.Statuses;
using NHNT.Exceptions;

namespace NHNT.Constants
{
    public enum DepartmentStatus
    {
        PENDING = 0,
        CANCEL = 1,
        ACCEPTED = 2,
    }

    public class DepartmentStatusHelper
    {
        public static DepartmentStatus Get(int value)
        {
            switch (value)
            {
                case 0:
                    return DepartmentStatus.PENDING;
                case 1:
                    return DepartmentStatus.CANCEL;
                case 2:
                    return DepartmentStatus.ACCEPTED;
                default:
                    throw new DataRuntimeException(StatusNotExist.DEPARTMENT_STATUS);
            }
        }
    }
}