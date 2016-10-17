using System;
using System.Linq;
using System.Web.Http;
using LoansTracking.DB.Entities;
using LoansTracking.DB.DataAccess;
using LoansTracking.WebApi.Models;

namespace LoansTracking.WebApi.Controllers
{
    public class NotesController : BaseController<Note>
    {
        public NotesController(Repository<Note> depo) : base(depo) { }

        public IHttpActionResult GetByID(int id)
        {
            try
            {
                Note note = Repository.Get(id);
                if (note == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Factory.Create(note));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Repository.Get().ToList().Select(x => Factory.Create(x)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Post(NoteModel model)
        {
            try
            {
                Note note = Parser.Create(model, Repository.BaseContext());
                Repository.Insert(note);
                var newNote = Repository.Get().OrderByDescending(x => x.Id).FirstOrDefault();
                return Ok(Factory.Create(newNote));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Put(int id, NoteModel model)
        {
            try
            {
                Note note = Repository.Get(id);
                if (note == null)
                {
                    return NotFound();
                }
                else
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), note.Id);
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Note note = Repository.Get(id);
                if (note == null)
                {
                    return NotFound();
                }
                else
                {
                    Repository.Delete(id);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
