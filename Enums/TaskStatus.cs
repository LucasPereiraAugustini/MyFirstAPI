using System.ComponentModel;

namespace WebAPI.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("In Progress")]
        InProgress = 2,
        [Description("Completed")]
        Completed = 3
    }
}
