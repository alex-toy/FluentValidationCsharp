using FluentValidation;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.Validators
{
    public class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator()
        {
            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("Description must not be empty."); ;

            RuleFor(t => t.DueDate)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("DueDate must be in the future.");

            When(t => t.RemindMe, () => { 
                RuleFor(t => t.ReminderMinutesBeforeDue)
                    .NotNull().WithMessage("When RemindMe, ReminderMinutesBeforeDue must be set")
                    .GreaterThan(0).WithMessage("ReminderMinutesBeforeDue must be greater than zero.")
                    .Must(value => value % 15 == 0).WithMessage("ReminderMinutesBeforeDue must be a multiple of 15.");
            });

            RuleForEach(t => t.SubItems)
                .NotEmpty().WithMessage("Values in SubItems cannot be empty.");
        }
    }
}
