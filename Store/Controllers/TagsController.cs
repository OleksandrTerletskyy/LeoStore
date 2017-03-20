using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Store.Data.Repositories.Abstract;
using Store.Entities.Concrete;
using Store.Infrastructure.Core;
using Store.Mappings;
using Store.ViewModels;

namespace Store.Controllers
{
	public class TagsController : ApiControllerBase
	{
		private IEntityBaseRepository<Tag> _tagRepository;
		private TagMapper _tagMapper ;

		public TagsController(IEntityBaseRepository<Error> errorRepository,
			IEntityBaseRepository<Tag> tagRepository,
			TagMapper tagMapper)
			: base(errorRepository)
		{
			_tagRepository = tagRepository;
			_tagMapper = tagMapper;
		}
		// GET: api/Tags
		public IEnumerable<TagViewModel> GetTags()
		{
			return _tagMapper.TagToTagVm(_tagRepository.All);
		}

		// GET: api/Tags/5
		[ResponseType(typeof(Tag))]
		public IHttpActionResult GetTag(int id)
		{
			Tag tag = _tagRepository.GetById(id);
			if (tag == null)
			{
				return NotFound();
			}
			return Ok(tag);
		}
		#region put,delete
		//// PUT: api/Tags/5
		//[ResponseType(typeof(void))]
		//public async Task<IHttpActionResult> PutTag(int id, Tag tag)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	if (id != tag.Id)
		//	{
		//		return BadRequest();
		//	}

		//	_db.Entry(tag).State = EntityState.Modified;

		//	try
		//	{
		//		await _db.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!TagExists(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}

		//	return StatusCode(HttpStatusCode.NoContent);
		//}

		//// POST: api/Tags
		//[ResponseType(typeof(Tag))]
		//public async Task<IHttpActionResult> PostTag(Tag tag)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	_db.Tags.Add(tag);
		//	await _db.SaveChangesAsync();

		//	return CreatedAtRoute("DefaultApi", new { id = tag.Id }, tag);
		//}

		//// DELETE: api/Tags/5
		//[ResponseType(typeof(Tag))]
		//public async Task<IHttpActionResult> DeleteTag(int id)
		//{
		//	Tag tag = await _db.Tags.FindAsync(id);
		//	if (tag == null)
		//	{
		//		return NotFound();
		//	}

		//	_db.Tags.Remove(tag);
		//	await _db.SaveChangesAsync();

		//	return Ok(tag);
		//}
		#endregion
		private bool TagExists(int id)
		{
			return _tagRepository.All.Count(e => e.Id == id) > 0;
		}
	}
}
