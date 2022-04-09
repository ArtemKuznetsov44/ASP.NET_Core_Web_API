using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerTests
    {
        private readonly CpuMetricsController _controller; 
        public CpuMetricsControllerTests() => _controller = new CpuMetricsController();

        [Fact]
        public void GetMetricsFromAgent_ReturnOk()
        {
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result); 
        }

        [Fact]
        public void GetMetricsFromAllCluster_ReturnOK()
        {
            var result = _controller.GetMetricsFromAllCluster(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result); 
        }
    }
}