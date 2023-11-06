using FluentValidation;
using webapi.Controllers;

public class CarValidator : AbstractValidator<CarsController.Car>
{
    public CarValidator()
    {
        RuleFor(car => car.Make).NotEmpty().WithMessage("The make of the car is required her >>>e.");
        RuleFor(car => car.Model).NotEmpty().WithMessage("The model of the car is required.");
    }
}