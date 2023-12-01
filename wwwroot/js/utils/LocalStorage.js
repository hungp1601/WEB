var LocalStorage = (() => {
  const getAccessToken = () => {
    return localStorage.getItem("token");
  };

  const setAccessToken = (token) => {
    localStorage.setItem("token", token);
  };

  const getRefreshToken = () => {
    return localStorage.getItem("refreshToken");
  };

  const setRefreshToken = (refreshToken) => {
    localStorage.setItem("refreshToken", refreshToken);
  };

  const setToken = (data) => {
    var token = JSON.parse(data);
    setAccessToken(token.accessToken);
    setRefreshToken(token.refreshToken);
  };

  const removeToken = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken")
  }

  const removeAccess = () => {
    localStorage.removeItem("token");
  }

  const removeRefresh = () => {
    localStorage.removeItem("refreshToken")
  }
  return {
    getAccess: getAccessToken,
    setAccess: setAccessToken,
    getRefresh: getRefreshToken,
    setRefresh: setRefreshToken,
    setToken: setToken,
    removeAccess: removeAccess,
    removeRefresh: removeRefresh,
    removeToken: removeToken,
  };
})();
