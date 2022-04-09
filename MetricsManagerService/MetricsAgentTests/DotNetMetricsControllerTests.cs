using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerTests
    {
        private readonly DotNetMetricsController _controller;

        public DotNetMetricsControllerTests() => _controller = new DotNetMetricsController();

        [Fact]
        public void GetMetric_ReturnOk()
        {
            var result = _controller.GetMetrics(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
