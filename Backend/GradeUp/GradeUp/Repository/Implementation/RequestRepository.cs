using GradeUp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradeUp.Repository.Implementation
{
    public class RequestRepository : IRequestRepository
    {
        private GradeUpContext _context;
        public RequestRepository()
        {
            _context = new GradeUpContext();
        }

        public Request getRequestById(long id)
        {
            return _context.Request.FirstOrDefault(r => r.id == id);
        }
        public List<Request> getRequestByIdUser1(long id_user1)
        {
            return _context.Request.Where(r => r.id_user1 == id_user1).ToList<Request>();
        }
        public List<Request> getRequestByIdUser2(long id_user2)
        {
            return _context.Request.Where(r => r.id_user2 == id_user2).ToList<Request>();
        }
        public void addRequest(Request request)
        {
            try
            {
                if (request != null)
                {
                    _context.Request.Add(request);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Invalid request informations.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the entity changes.", ex);
            }
        }
        public void updateRequest(Request request)
        {
            try
            {
                Request requestToUpdate = _context.Request.FirstOrDefault(requestToUpdate => requestToUpdate.id == request.id);
                if (requestToUpdate != null)
                {
                    //_context.Request.Update(requestToUpdate);
                    requestToUpdate.id_user1 = request.id_user1;
                    requestToUpdate.id_user2 = request.id_user2;
                    requestToUpdate.id_subject = request.id_subject;
                    requestToUpdate.accepted = request.accepted;
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Request information was not updated.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }
        public void deleteRequestById(long id)
        {
            try
            {
                Request requestToDelete = _context.Request.FirstOrDefault(r => r.id == id);
                if (requestToDelete != null)
                {
                    _context.Request.Remove(requestToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Request not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }

        public void deleteRequestByIdUser(long id_user)
        {
            try
            {
                var requestToDelete = _context.Request.Where(r => r.id_user1 == id_user || r.id_user2 == id_user);
                if (requestToDelete != null)
                {
                    _context.Request.RemoveRange(requestToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Request not found.");
                }


            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }

        }
    }
}
