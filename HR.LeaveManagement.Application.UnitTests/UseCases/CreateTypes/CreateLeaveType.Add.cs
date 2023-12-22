using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.CreateLeaveType;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.UseCases.CreateTypes;
public class CreateLeaveType
{
    private readonly IMapper _mapper;
    private readonly IMock<ILeaveTypeRepository> _leaveTypeRepositoryMock;
    private readonly Mock<IValidator<CreateLeaveTypeDtoValidator>> _validator;
    public CreateLeaveType()
    {
        _leaveTypeRepositoryMock = LeaveTypeRepositoryMock.GetMockLeaveTypeRepository();
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();


        _validator = new Mock<IValidator<CreateLeaveTypeDtoValidator>>(MockBehavior.Strict);

    }

    [Fact]
    public async Task Handle_ValidLeaveType()
    {
        var leaveType = new CreateLeaveTypeDto()
        {
            Name = "Kasal",
            DefaultDays = 1,
        };
        var handler = new CreateLeaveTypeCommandHandler(_leaveTypeRepositoryMock.Object, _mapper);

        await handler.Handle(new CreateLeaveTypeCommand { LeaveTypeDto = leaveType }, CancellationToken.None);

        var leaveTypes = await _leaveTypeRepositoryMock.Object.GetAllAsync();
        leaveTypes.Count.ShouldBe(4);
    }

    [Fact]
    public async Task Handle_InValidLeaveType()
    {
        var leaveType = new CreateLeaveTypeDto()
        {
            Name = "Kasal",
            DefaultDays = -1,
        };
        var handler = new CreateLeaveTypeCommandHandler(_leaveTypeRepositoryMock.Object, _mapper);

        await handler.Handle(new CreateLeaveTypeCommand { LeaveTypeDto = leaveType }, CancellationToken.None);

        var leaveTypes = await _leaveTypeRepositoryMock.Object.GetAllAsync();
        leaveTypes.Count.ShouldBe(3);
    }


}
