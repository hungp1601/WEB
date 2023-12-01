document.addEventListener("DOMContentLoaded", () => {
  var username = document.getElementById("username");
  var messUsername = document.getElementById("messUsername");

  var email = document.getElementById("email");
  var messEmail = document.getElementById("messEmail");

  var password = document.getElementById("password");
  var messPassword = document.getElementById("messPassword");

  var rePassword = document.getElementById("rePassword");
  var messRePassword = document.getElementById("messRePassword");

  var fullName = document.getElementById("fullName");
  var messFullName = document.getElementById("messFullName");

  var birthday = document.getElementById("birthday");
  var messBirthday = document.getElementById("messBirthday");

  var gender = document.getElementById("gender");

  var phone = document.getElementById("phone");
  var messPhone = document.getElementById("messPhone");

  var btnRegister = document.getElementById("btnRegister");

  ///

  username.addEventListener("focusout", () => {
    validUsername(username.value, messUsername);
  });
  username.addEventListener("keydown", () => {
    hideMess(messUsername);
  });

  email.addEventListener("focusout", () => {
    validEmail(email.value, messEmail);
  });
  email.addEventListener("keydown", () => {
    hideMess(messEmail);
  });

  password.addEventListener("focusout", () => {
    validPassword(password.value, messPassword);
  });
  password.addEventListener("keydown", () => {
    hideMess(messPassword);
  });

  rePassword.addEventListener("focusout", () => {
    validRePassword(password.value, rePassword.value, messRePassword);
  });
  rePassword.addEventListener("keydown", () => {
    hideMess(messRePassword);
  });

  fullName.addEventListener("focusout", () => {
    validFullName(fullName.value, messFullName);
  });
  fullName.addEventListener("keydown", () => {
    hideMess(messFullName);
  });

  birthday.addEventListener("focusout", () => {
    validBirthday(birthday.value, messBirthday);
  });
  birthday.addEventListener("keydown", () => {
    hideMess(messBirthday);
  });
  birthday.addEventListener("click", () => {
    hideMess(messBirthday);
  });

  phone.addEventListener("focusout", () => {
    validPhone(phone.value, messPhone);
  });
  phone.addEventListener("keydown", () => {
    hideMess(messPhone);
  });

  btnRegister.addEventListener("click", function (e) {
    e.preventDefault();

    if (
      !validUsername(username.value, messUsername) ||
      !validEmail(email.value, messEmail) ||
      !validPassword(password.value, messPassword) ||
      !validRePassword(password.value, rePassword.value, messRePassword) ||
      !validFullName(fullName.value, messFullName) ||
      !validBirthday(birthday.value, messBirthday) ||
      !validPhone(phone.value, messPhone)
    ) {
      return;
    }

    const data = {
      username: username.value,
      email: email.value,
      password: password.value,
      rePassword: rePassword.value,
      fullName: fullName.value,
      birthday: birthday.value,
      gender: gender.value,
      phone: phone.value,
    };

    CustomRequest.postForm({
      url: "https://localhost:5001/Account/Register",
      addToken: false,
      data: data,
      callback: (response) => {
        LocalStorage.setToken(response);
        ToastMessage.show({
          type: "success",
          title: "Thành công!",
        });
        const json = JSON.parse(response);
        console.log(json);
        window.location.href = "https://localhost:5001/";
      },
    });
  });
});

const hideMess = (mess) => {
  mess.textContent = "";
  mess.style.display = "none";
};

const validUsername = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập tên đăng nhập";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validEmail = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập email";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validPassword = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập mật khẩu của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validRePassword = (valuePassword, valueRePassword, mess) => {
  if (valueRePassword === "") {
    mess.textContent = "Vui lòng nhập lại mật khẩu của bạn";
    mess.style.display = "block";
    return false;
  }

  if (valueRePassword !== valuePassword) {
    mess.textContent = "Mật khẩu không khớp";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validFullName = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập họ và tên của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validBirthday = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập ngày sinh của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validGender = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập giới tính của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validPhone = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập số điện thoại của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};
