using SchoolBLL.Implementations;
using SchoolBLL.Interfaces;

namespace SchoolAPI.Configuration
{
    public static class DependencyInjections
    {
        public static void AddBLL(this IServiceCollection services)
        {
            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IStudentBLL, StudentBLL>();
            services.AddScoped<ITeacherBLL, TeacherBLL>();
            services.AddScoped<IClassBLL, ClassBLL>();
            services.AddScoped<IEnrollmentBLL, EnrollmentBLL>();
            services.AddScoped<IGradeBLL, GradeBLL>();
            services.AddScoped<IEvaluationBLL, EvaluationBLL>();
            services.AddScoped<IStudentGradeBLL, StudentGradeBLL>();
        }
    }
}
