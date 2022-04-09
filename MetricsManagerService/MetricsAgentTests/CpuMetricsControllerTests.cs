using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerTests
    {
        private readonly CpuMetricsController _controller; 

        public CpuMetricsControllerTests() => _controller = new CpuMetricsController();

        [Fact]
        public void GetMetric_ReturnOk()
        {
            var result = _controller.GetMetrics(TimeSpan.Zero, TimeSpan.Zero); 
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}