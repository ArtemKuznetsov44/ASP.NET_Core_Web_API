using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerTests
    {
        private readonly HddMetricsController _controller;

        public HddMetricsControllerTests() => _controller = new HddMetricsController();

        [Fact]
        public void GetMetric_ReturnOk()
        {
            var result = _controller.GetMetrics(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
