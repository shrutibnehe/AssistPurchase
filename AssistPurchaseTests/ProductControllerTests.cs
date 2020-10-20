using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AssistPurchaseCaseStudy.Controllers;
using AssistPurchaseCaseStudy.Models;
using AssistPurchaseCaseStudy.Repository;
using AssistPurchaseCaseStudy.Utility;


namespace AssistPurchaseTests
{
    public class ProductControllerTests
    {
        ProductController _productsController;
        public ProductControllerTests()
        {
            IProductRepository repository = new ProductRepository();
            _productsController = new ProductController(repository);
        }



        [Theory]
        [InlineData("Features", "Services")]
        [InlineData("Services" , "DisplaySize")]
        [InlineData( "DisplaySize", "lastLayer")]
        [InlineData("WrongResponse", "Invalid RequestResponse Sent")]
        public void WhenNextQuestionRequestedThenReturnNextLayerIfInputValid(string sentLayer, string expectedReceivedLayer)
        {
            var sentResponse = new RequestResponse();
            sentResponse.Layer = sentLayer;
            var receivedResponse = _productsController.GetNextQuestion(sentResponse);
            var actual = receivedResponse.Layer;
            Assert.Equal(expectedReceivedLayer, actual);
        }

        [Theory]
        [InlineData("Features", "ESN", "Invalid RequestResponse Sent")]
        [InlineData("Services", "upto 10", "Invalid RequestResponse Sent")]
        [InlineData("DisplaySize", "Services", "Invalid RequestResponse Sent")]
        [InlineData("DisplaySize", "upto 10", "lastLayer")]
        public void WhenInvalidResponseThenReturnMessageInLayer(string sentLayer, string sentLayerMember, string expectedReceivedLayer)
        {
            var sentResponse = new RequestResponse();
            sentResponse.Layer = sentLayer;
            sentResponse.LayerMembers = new string[]{ sentLayerMember};
            var receivedResponse = _productsController.GetNextQuestion(sentResponse);
            var actual = receivedResponse.Layer;
            Assert.Equal(expectedReceivedLayer, actual);
        }

    }
}
