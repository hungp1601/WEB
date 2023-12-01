document.addEventListener("DOMContentLoaded", function () {
  var username = document.getElementById("username");
  var password = document.getElementById("password");
  var messUsername = document.getElementById("valid-username");
  var messPassword = document.getElementById("valid-password");
  var buttonSubmit = document.getElementById("btn-submit");

  const validUsername = () => {
    if (username.value === "") {
      messUsername.textContent = "Vui lòng nhập tên người dùng";
      messUsername.style.display = "block";
      return false;
    }

    return true;
  };

  const validPassword = () => {
    if (password.value === "") {
      messPassword.textContent = "Vui lòng nhập mật khẩu";
      messPassword.style.display = "block";
      return false;
    }

    return true;
  };

  username.addEventListener("keydown", function () {
    messUsername.textContent = "";
    messUsername.style.display = "none";
  });
  username.addEventListener("focusout", validUsername);

  password.addEventListener("keydown", function () {
    messPassword.textContent = "";
    messPassword.style.display = "none";
  });
  password.addEventListener("focusout", validPassword);

  buttonSubmit.addEventListener("click", function (e) {
    e.preventDefault();

    if (!validUsername() || !validPassword()) {
      return;
    }

    CustomRequest.postForm({
      url: "https://localhost:5001/Account/Login",
      addToken: false,
      data: {
        username: username.value,
        password: password.value,
      },
      callback: (response) => {
        var dataJson = JSON.parse(response);
        LocalStorage.setToken(response);
        localStorage.setItem("username", username.value);
        // ToastMessage.show({
        //   type: "success",
        //   title: "Thành công!",
        //   message: dataJson.expiredTime
        // });
        window.location.href = "https://localhost:5001/";
      },
    });
  });
});
