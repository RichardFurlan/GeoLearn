using GeoLearn.Application.Quiz;
using GeoLearn.Application.Quiz.DTO;
using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Enums;
using GeoLearn.Domain.Repositories;
using Moq;

namespace GeoLearn.Test.Application.Quiz;

public class AplicQuizTest
{
    private readonly Mock<IQuizRepository> _mockQuizRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IQuizAnswerRepository> _mockQuizAnswerRepository;
    private readonly AplicQuiz _aplicQuiz;

    
    public AplicQuizTest()
    {
        _mockQuizRepository = new Mock<IQuizRepository>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockQuizAnswerRepository = new Mock<IQuizAnswerRepository>();
        _aplicQuiz = new AplicQuiz(
            _mockQuizRepository.Object,
            _mockUserRepository.Object,
            _mockQuizAnswerRepository.Object
        );
    }
    
    // TODO: Criar unit test
}