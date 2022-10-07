using AnnoFlow.Api.Models.Datasets;
using AnnoFlow.Core.Entities;
using AnnoFlow.Core.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AnnoFlow.Api.Controllers
{
    public class DatasetsController : ApiController
    {
        private readonly IDatasetsRepository _datasetsRepository;

        public DatasetsController(ILogger<DatasetsController> logger,
                                  IDatasetsRepository datasetsRepository)
            : base(logger)
        {
            _datasetsRepository = datasetsRepository;
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(Dataset), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDatasetAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dataset = await _datasetsRepository.FindAsync(id);

            if (dataset == null)
            {
                return NotFound(id);
            }

            return Ok(dataset);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Dataset), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostDatasetAsync([FromBody] CreateDataset model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingDataset = await _datasetsRepository.FindAsync(model.Id);

            if (existingDataset != null)
            {
                return Conflict(model.Id);
            }

            var newDataset = new Dataset(model.Id, new Version(1, 0));

            await _datasetsRepository.InsertAsync(newDataset);

            return Ok(newDataset);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(typeof(Dataset), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteDatasetAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var existingDataset = await _datasetsRepository.FindAsync(id);

            if (existingDataset != null)
            {
                await _datasetsRepository.DeleteAsync(existingDataset);
            }

            return Ok();
        }
    }
}