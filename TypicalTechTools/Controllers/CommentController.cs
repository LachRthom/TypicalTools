﻿using Microsoft.AspNetCore.Mvc;
using TypicalTechTools.Models;
using TypicalTechTools.Models.Repositories;
using System;

namespace TypicalTools.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult CommentList(int id)
        {
            var comments = _commentRepository.GetAllComments(id);
            return View(comments);
        }

        [HttpGet]
        public IActionResult AddComment(int productId)
        {
            var comment = new Comment { ProductId = productId };
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }

            // Retrieve the session ID from the current session
            string sessionId = HttpContext.Session.GetString("SessionId");

            // If the session ID doesn't exist, generate a new one
            if (string.IsNullOrEmpty(sessionId))
            {
                sessionId = Guid.NewGuid().ToString();
                // Store the session ID in the session to maintain consistency throughout the user's session
                HttpContext.Session.SetString("SessionId", sessionId);
            }

            // Set the session ID in the comment
            comment.SessionId = sessionId;

            // Set the CreatedDate for the comment
            comment.CreatedDate = DateTime.Now;

            _commentRepository.AddComment(comment);

            return RedirectToAction("Index", "Product");
        }

        public IActionResult RemoveComment(int commentId)
        {
            _commentRepository.DeleteComment(commentId);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult EditComment(int commentId)
        {
            var comment = _commentRepository.GetCommentById(commentId);
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                // Model state is not valid, return the view with validation errors
                return View(comment);
            }

            // Retrieve the session ID from the current session 
            string sessionId = HttpContext.Session.GetString("SessionId");

            // Set the session ID in the comment
            comment.SessionId = sessionId;

            _commentRepository.UpdateComment(comment);

            return RedirectToAction("Index", "Product");
        }
    }
}
