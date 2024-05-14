using GradeUp.Entities;

namespace GradeUp.Repository
{
    public interface IReviewRepository
    {
        Review getReviewById(long id);
        List<Review> getReviewByIdUser(long id_user);
        void addReview(Review review);
        void updateReview(Review review);
        void deleteReviewById(long id);
        void deleteReviewByIdUser(long id_user);

    }
}
