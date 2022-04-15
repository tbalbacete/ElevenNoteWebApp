﻿using ElevenNoteWebApp.Shared.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenNoteWebApp.Server.Services.Note
{
    public interface INoteService
    {
        Task<IEnumerable<NoteListItem>> GetAllNotesAsync();
        Task<bool> CreateNoteAsync(NoteCreate model);
        Task<NoteDetail> GetNoteByIdAsync(int noteId);
        Task<bool> UpdateNoteAsync(NoteEdit model);
        Task<bool> DeleteNoteAsync(int noteId);
        void SetUserId(string userId);
    }
}
