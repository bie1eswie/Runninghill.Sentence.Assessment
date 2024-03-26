using AutoMapper;
using Azure;
using Moq;
using Runninghill.Common.Tests.Common;
using Runninghill.Sentence.Assessment.Application.Models;
using Runninghill.Sentence.Assessment.Application.Services;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using Runninghill.Sentence.Assessment.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Runninghill.Sentence.Assessment.Application.Models.WordGroupDTO;

namespace Application.Tests.Services
{
    public class WordItemServiceTests: RunninghillTestBase
    {
        private WordItemService _wordItemService;
        private IMapper _mapper;
        private WordRepository _wordRepository;
        [SetUp]
        public void SetUp()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => { 
                cfg.AddProfile(new WordGroupProfile());
                cfg.AddProfile(new WordItemDTO.WordItemProfile());
            }));
            _mocker.SetInstance(_mapper);
            _wordRepository = _mocker.Create<WordRepository>();
            _wordItemService = new WordItemService(_wordRepository,_mapper);
            _mocker.SetInstance(_wordItemService);
        }
        [Test]
        public async Task Get_WordItems_With_A_WordGroup()
        {
            var expectedValue = "apple";
            var words = await _wordRepository.GetWordItemsAsync(WordType.Noun);

            _mocker
                    .GetMock<IWordRepository>()
                    .Setup(x => x.GetWordItemsAsync(It.IsAny<WordType>()))
                    .ReturnsAsync(words);

            var result = await _wordItemService.GetWordItemsAsync(WordType.Noun);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Items, Is.Not.Null);
            var actualValue = result.Items.FirstOrDefault(x=>x.Word ==  expectedValue);
            Assert.That(actualValue, Is.Not.Null);
            Assert.That(actualValue.Word, Is.EqualTo(expectedValue));
            TearDown();
        }
    }
}
