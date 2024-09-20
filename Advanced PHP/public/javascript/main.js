function insertNewComment(text, id) {
    fetch("add_comment.php", {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded",
        },
        body: "comment_text=" + encodeURIComponent(text) + "&new_comment_id=" + id,
    })
        .then((response) => response.json())
        .then((data) => {
            fetchComments(id);
            console.log(data.comments);
            console.log(id);
        })
        .catch((error) => {
            console.error("Error:", error);
        });
}

blogPosts.addEventListener("click", (event) => {
    console.log(event.target);
    event.preventDefault();
    if (event.target.classList.contains("card-title")) {
        let anchor = event.target.closest("a");
        let id = anchor.getAttribute("data-id");
        console.log(id);

        fetch("getPost.php", {
            method: "POST",
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
            },
            body: "blog_id=" + id,
        })
            .then((response) => response.json())
            .then((data) => {
                // Output blog to the page
                console.log(data);
                modalTitle.innerText = data.title;
                modalBody.innerText = data.body;
                fetchComments(data.id);
                commentPostId.setAttribute("value", data.id);
                modalImg.setAttribute("src", data.img_url);
                modalBtn.click();
            });
    }
});

function fetchComments(id) {
    console.log("Fetching comments for: " + id);
    fetch("getComments.php", {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded",
        },
        body: "comment_post_id=" + id,
    })
        .then((response) => response.json())
        .then((data) => {
            let output = "";
            data.forEach((c) => {
                output += `<p>${c.comment_text}</p><h5>User: ${c.user_id}</h5><hr>`;
            });
            commentOutput.innerHTML = output;
        });
}

// Event handler for comment form submission
commentForm.addEventListener("submit", (event) => {
    event.preventDefault();
    const commentText = commentTextElement.value;
    const postId = commentPostId.value;
    insertNewComment(commentText, postId);
    commentTextElement.value = ""; // Clear the comment text input
});
