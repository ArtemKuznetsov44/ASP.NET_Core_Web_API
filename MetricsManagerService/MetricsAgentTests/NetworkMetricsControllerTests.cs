using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerTests
    {
        private readonly NetworkMetricsController _controller;

        public NetworkMetricsControllerTests() => _controller = new NetworkMetricsController();

        [Fact]
        public void GetMetric_ReturnOk()
        {
            var result = _controller.GetMetrics(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}