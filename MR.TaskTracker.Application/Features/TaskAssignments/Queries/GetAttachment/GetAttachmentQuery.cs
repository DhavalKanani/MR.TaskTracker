using System;
using MediatR;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Models.File;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAttachment
{
    public class GetAttachmentQuery : IRequest<FileModel>
    {
        public int TaskAttachmentId  { get; set; }
    }
}

