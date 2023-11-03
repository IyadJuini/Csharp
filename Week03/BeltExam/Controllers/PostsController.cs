using BeltExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BeltExam.Controllers;

public class PostsController : Controller

{
    private readonly MyContext _context;
    public PostsController(MyContext context)
    {
        _context = context;
    }

    // .............................. Check If The User Is Connected ................................
    [HttpGet("posts/new")]
    public IActionResult SellPost()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg","Users");
        }
        return View();
    }
    // .............................................................................................


    // ....................................... CREATE Post ........................................
    [HttpPost("posts/create")]
    public IActionResult CreatePost(Post newPost)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newPost);
            _context.SaveChanges();
            return RedirectToAction("ShowPost","Posts", new{postId= newPost.PostId});
        }
        return View("SellPost");
    }
    // ..............................................................................................

        // ................................ Get ONE Post By Id With his Poster (SHOW POSTS) ............................
    [HttpGet("posts/{postId}")]
    public IActionResult ShowPost(int postId )
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg","Users");
        }
        Post? OnePost = _context.Posts.Include(post => post.Poster).Include(p => p.PostLikes).FirstOrDefault(post => post.PostId == postId);
        return View(OnePost);
    }


    // ...........................GET ALL Posts With Their Poster And Likes....................................
    [HttpGet("posts")]
    public IActionResult AllPosts()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg","Users");
        }
        List<Post> AllPosts = _context.Posts.Include(post => post.Poster).Include(p => p.PostLikes).ToList();
        // System.Console.WriteLine(AllPosts.ToArray());
        // AllPostsView x = new AllPostsView(){};
        // x.AllPosts=AllPosts;
        // x.Like = AllPosts.PostLikes;
        return View(AllPosts);
    }
    // ................................................................................................




    // ........................................ DELETE Post ..........................................
        [HttpPost()]
    public IActionResult DeletePost(int postId)
    {
        Post? PostToDelete = _context.Posts
        .FirstOrDefault(c => c.PostId == postId);
        //1 Add 
        _context.Remove(PostToDelete);
        //2 Save
        _context.SaveChanges();
        return RedirectToAction("AllPosts", "Posts");
    }
    // .............................................................................................


    // ................................ GET ONE BY ID (Post To Edit) ...............................
    [HttpGet("/post/{postId}/edit")]
    public IActionResult EditPost(int postId)
    {
        Post? PostToUpdate = _context.Posts
        .FirstOrDefault(c => c.PostId == postId);

        return View(PostToUpdate);
    }
    // ............................................................................................


    // ..................................... EDIT Post ............................................
    [HttpPost()]
    public IActionResult EditedPost(Post editedPost)
    {
        Post? PostToUpdate = _context.Posts
        .FirstOrDefault(d => d.PostId == editedPost.PostId);
        if (ModelState.IsValid)
        {
            PostToUpdate.ImageUrl = editedPost.ImageUrl;
            PostToUpdate.Title = editedPost.Title;
            PostToUpdate.Medium = editedPost.Medium;
            PostToUpdate.ForSale = editedPost.ForSale;
            PostToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ShowPost",new{postId = PostToUpdate.PostId});
        }
        return View("EditPost",PostToUpdate);
    }
    // ...............................................................................................

}