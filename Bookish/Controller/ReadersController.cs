using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Manager.Services;
using static Models.ReaderModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly IReaderService _readerService;

        public ReadersController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reader>> GetReader()
        {
            return Ok(_readerService.GetAllReader());
        }

        [HttpGet("{id}")]
        public ActionResult<Reader> GetReader(int id)
        {
            var reader = _readerService.GetReaderById(id);
            if (reader == null)
            {
                return NotFound();
            }
            return Ok(reader);
        }

        [HttpPost]
        public ActionResult AddReader(Reader reader)
        {
            _readerService.AddReader(reader);
            return CreatedAtAction(nameof(GetReader), new { id = reader.Id }, reader);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReader(int id, Reader reader)
        {
            var existingReader = _readerService.GetReaderById(id);
            if (existingReader == null)
            {
                return NotFound();
            }

            _readerService.UpdateReader(id, reader);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReader(int id)
        {
            var reader = _readerService.GetReaderById(id);
            if (reader == null)
            {
                return NotFound();
            }

            _readerService.DeleteReader(id);
            return NoContent();
        }
    }
}