using AutoMapper;
using MediatR;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Models.File;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAttachment
{
    public class GetAttachmentQueryHandler : IRequestHandler<GetAttachmentQuery, FileModel>
    {
        private readonly ITaskAttachmentRepository _taskAttachmentRepository;
        private readonly IMapper _mapper;

        public GetAttachmentQueryHandler(ITaskAttachmentRepository taskAttachmentRepository, IMapper mapper)
        {
            _taskAttachmentRepository = taskAttachmentRepository;
            _mapper = mapper;
        }

        public async Task<FileModel> Handle(GetAttachmentQuery request, CancellationToken cancellationToken)
        {
            var taskAttachment = await _taskAttachmentRepository.GetByIdAsync(request.TaskAttachmentId);
            return _mapper.Map<FileModel>(taskAttachment);
        }
    }

}

