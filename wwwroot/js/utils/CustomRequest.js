var CustomRequest = (function () {
  var xhr = new XMLHttpRequest();

  function request(
    method,
    url,
    data,
    contentType,
    addToken = false,
    success,
    fail = undefined
  ) {
    xhr.open(method, url, true);

    if (addToken) {
      setTokenHeader();
    }

    xhr.onreadystatechange = function () {
      if (xhr.readyState === 4) {
        if (xhr.status >= 200 && xhr.status < 300) {
          if (typeof success === "function") {
            success(xhr.responseText);
          }
        } else {
          if (typeof fail === "function") {
            fail(xhr.responseText);
          } else {
            handleErrorRequest(xhr.status, JSON.parse(xhr.responseText));
          }
        }
      }
    };

    // thêm time out

    if (contentType === "json") {
      xhr.setRequestHeader("Content-Type", "application/json; charset=UTF-8");
      var data = JSON.stringify(data);
      xhr.send(data);
    } else if (contentType === "form") {
      var formData = new FormData();
      console.log("step 1", data);
      addFormData(formData, data);
      xhr.send(formData);
    } else {
      xhr.send();
    }
  }

  function addFormData(formData, data, parentKey) {
    if (data && typeof data === "object") {
      Object.keys(data).forEach((key) => {
        const value = data[key];
        const formKey = parentKey ? `${parentKey}[${key}]` : key;
        if (value instanceof FileList) {
          for (let i = 0; i < value.length; i++) {
            formData.append(formKey, value[i], value[i].name);
          }
        } else if (value && typeof value === "object") {
          addFormData(formData, value, formKey);
        } else {
          formData.append(formKey, value);
        }
      });
    }
  }

  function setTokenHeader() {
    const token = localStorage.getItem("token");
    if (token) {
      xhr.setRequestHeader("Authorization", "Bearer " + token);
    }
  }

  function handleErrorRequest(status, data) {
    if (status == 400) {
      ToastMessage.show({
        type: "warning",
        title: "WARNING",
        message: data.Message,
      });
      return;
    }

    if (status == 401) {
      ToastMessage.show({
        type: "warning",
        title: "WARNING",
        message: data.Message,
      });
      return;
    }

    if (status == 403) {
      ToastMessage.show({
        type: "warning",
        title: "WARNING!",
        message: data.Message,
      });
      return;
    }

    if (status == 500) {
      ToastMessage.show({
        type: "error",
        title: "ERROR!",
        message: data.Message,
      });
      return;
    }

    // ...
  }

  function get({ url, addToken, callback, failCallBack }) {
    request("GET", url, null, null, addToken, callback, failCallBack);
  }

  function getForm({ url, addToken, data, callback, failCallBack }) {
    request("GET", url, data, "form", addToken, callback, failCallBack);
  }

  function postJson({ url, addToken, data, callback, failCallBack }) {
    request("POST", url, data, "json", addToken, callback, failCallBack);
  }

  function postForm({ url, addToken, data, callback, failCallBack }) {
    request("POST", url, data, "form", addToken, callback, failCallBack);
  }

  function putJson({ url, addToken, data, callback, failCallBack }) {
    request("PUT", url, data, "json", addToken, callback, failCallBack);
  }

  function putForm({ url, addToken, data, callback, failCallBack }) {
    request("PUT", url, data, "form", addToken, callback, failCallBack);
  }

  function del({ url, addToken, callback, failCallBack }) {
    request("DELETE", url, null, null, addToken, callback, failCallBack);
  }

  function delJson({ url, addToken, data, callback, failCallBack }) {
    request("DELETE", url, data, "json", addToken, callback, failCallBack);
  }

  return {
    get: get,
    getForm: getForm,
    postJson: postJson,
    postForm: postForm,
    putJson: putJson,
    putForm: putForm,
    delete: del,
    deleteJson: delJson,
    handleErrorRequest: handleErrorRequest,
  };
})();
