using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsControllerTests
    {
        private readonly RamMetricsController _controller;

        public RamMetricsControllerTests() => _controller = new RamMetricsController();

        [Fact]
        public void GetMetric_ReturnOk()
        {
            var result = _controller.GetMetrics(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
