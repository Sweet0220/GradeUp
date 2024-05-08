using GradeUp.Entities;
using GradeUp.Repository;
using GradeUp.Repository.Implementation;

namespace GradeUp.Services
{
    public class RequestService
    {
        private readonly IRequestRepository requestRepository;
        public RequestService()
        {
            requestRepository = new RequestRepository();
        }

        public Request getById(long id)
        {
            return requestRepository.getRequestById(id);
        }

        public List<Request> getByIdUser1(long id_user1)
        {
            return requestRepository.getRequestByIdUser1(id_user1);
        }

        public List<Request> getByIdUser2(long id_user2)
        {
            return requestRepository.getRequestByIdUser2(id_user2);
        }

        public void add_request(Request request)
        {
            requestRepository.addRequest(request);
        }

        public void update_request(Request request)
        {
            requestRepository.updateRequest(request);
        }

        public void deleteById(long id)
        {
            requestRepository.deleteRequestById(id);
        }

        public void deleteByIdUser(long id_user)
        {
            requestRepository.deleteRequestByIdUser(id_user);
        }
    }
}
