<?php


class Post
{
    protected $conn;

    public function __construct($conn)
    {
        $this->conn = $conn;
    }

    public function fetchAll()
    {
        $sql = "SELECT * FROM posts JOIN user on posts.post_author=user.id";
        $stmt = $this->conn->prepare($sql);
        $stmt->execute();
        $results = $stmt->get_result();
        return $results->fetch_all(MYSQLI_ASSOC);
    }
    public function fetchPost($id)
    {
        $sql = "SELECT * FROM posts WHERE id = ?";
        $stmt = $this->conn->prepare($sql);
        $stmt->bind_param("s", $id);
        $stmt->execute();
        $result = $stmt->get_result();
        return $result->fetch_assoc();
    }
    public function fetchID($id)
    {
        $sql = "SELECT * FROM posts JOIN user ON posts.post_author = user.id AND user.id = ?";
        $stmt = $this->conn->prepare($sql);
        $stmt->bind_param("s", $id);
        $stmt->execute();
        $results = $stmt->get_result();
        return $results->fetch_all(MYSQLI_ASSOC); // Fetch all rows as an associative array
    }



    public function create($post, $files)
    {
        $errors = [];
        $img = $files['blog_img'];
        $title = $post['title'];
        $body = $post['body'];
        $file_name = $img['name'];
        $file_ext = strtolower(pathinfo($file_name, PATHINFO_EXTENSION));
        $file_size = $img['size'];
        $file_error = $img['error'];

        if ($file_error == UPLOAD_ERR_OK) {
            $allowed_ext = ['png', 'jpg', 'jpeg', 'gif'];
            if (!in_array($file_ext, $allowed_ext)) {
                $errors['file_ext'] = "Improper file extension!";
            }
            if ($file_size > 500000000) {
                $errors['file_size'] = "Files must be smaller than 5mb!";
            }
        } else {
            $errors['img_error'] = "There was a problem with the image!";
        }

        if (empty($errors)) {
            $imageDir = "images/";
            if (!is_dir($imageDir)) {
                mkdir($imageDir, 0777, true);
            }
            $destination = $imageDir . $file_name;
            if (move_uploaded_file($img['tmp_name'], $destination)) {
                $sql = "INSERT INTO posts (title, body, img_url, post_author) VALUES (?,?,?,?)";
                $stmt = $this->conn->prepare($sql);
                $stmt->bind_param("ssss", $title, $body, $destination, $_SESSION['user_id']);
                $stmt->execute();
                if ($stmt->insert_id != 0) {
                    return $stmt->insert_id;
                } else {
                    return false;
                }
            } else {
                $errors['img_error'] = "There was a problem uploading the image!";
            }
        }

        return $errors;
    }


}

?>