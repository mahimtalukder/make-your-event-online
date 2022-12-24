import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="container d-flex align-items-center justify-content-center form-height-login pt-24px pb-24px">
      <div className="row justify-content-center">
        <div className="col-lg-6 col-md-10">
          <div className="card">
            <div className="card-header bg-primary">
              <div className="ec-brand">
                <a href="index.html" title="Ekka">
                  <img className="ec-brand-icon" src="assets/img/logo/logo-login.png" alt=""></img>
                </a>
              </div>
            </div>
            <div className="card-body p-5">
              <h4 className="text-dark mb-5">Sign In</h4>

              <form >
                <div className="row">
                  <div className="form-group col-md-12 mb-4">
                    <input type="text" className="form-control" id="username" placeholder="Username" ></input>
                  </div>

                  <div className="form-group col-md-12 ">
                    <input type="password" className="form-control" id="password" placeholder="Password" ></input>
                  </div>

                  <div className="col-md-12">
                    <div className="d-flex my-2 justify-content-between">

                      <p><a className="text-blue" href="#">Forgot Password?</a></p>
                    </div>

                    <button type="submit" className="btn btn-primary btn-block mb-4">Sign In</button>

                    <p className="sign-upp">Don't have an account yet ?
                      <button className="text-blue">Sign Up</button>
                    </p>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
