// utils/request.ts
import axios, {
  AxiosInstance,
  AxiosRequestConfig,
  AxiosResponse,
  InternalAxiosRequestConfig,
  AxiosError,
} from 'axios';
// 前后端定义统一的响应结构
export interface BaseResponse<T = any> {
  code: number;
  message?: string;
  success?:boolean;
  data: T;
}

// 扩展 AxiosRequestConfig
export interface RequestConfig extends AxiosRequestConfig {
  // 可以添加自定义配置
  showLoading?: boolean;
  showError?: boolean;
}

// 创建 axios 实例,顺便对request和response的头进行设置
const createAxiosInstance = (baseURL?: string): AxiosInstance => {
  const instance = axios.create({
    baseURL: baseURL || '/api', // API 前缀
    timeout: 30000, // 超时时间
    headers: {
      'Content-Type': 'application/json',
    },
  });

  // 请求拦截器
  instance.interceptors.request.use(
    (config: InternalAxiosRequestConfig) => {
      // 可以在这里添加 token 等
      const token = localStorage.getItem('token');
      if (token) {
        config.headers.Authorization = `Bearer ${token}`;
      }

      // 如果是 GET 请求，添加时间戳防止缓存
      if (config.method?.toUpperCase() === 'GET') {
        config.params = {
          ...config.params,
          _t: Date.now(),
        };
      }

      // 可以在这里添加 loading 等
      if ((config as RequestConfig).showLoading !== false) {
        // 显示 loading
        console.log('显示 loading');
      }

      return config;
    },
    (error: AxiosError) => {
      return Promise.reject(error);
    }
  );

  // 响应拦截器
  instance.interceptors.response.use(
    (response: AxiosResponse) => {
      // 隐藏 loading
      if ((response.config as RequestConfig).showLoading !== false) {
        console.log('隐藏 loading');
      }

      // 根据业务状态码处理
      const data = response.data as BaseResponse;
      
      // 如果后端返回的是 BaseResponse 结构
      if (data && typeof data === 'object' && 'code' in data) {
        if (data.code === 200 || data.code === 0) {
          ///response {data: {…}, status: 200, statusText: 'OK', headers: AxiosHeaders, config: {…}, …}-----response中的data才是后端返回的统一返回格式
          return response;
        } else {
          // 业务错误
          if ((response.config as RequestConfig).showError !== false) {
            // 可以在这里统一显示错误提示
            console.error('业务错误:', data.message || '请求失败');
          }
          return Promise.reject(new Error(data.message || '请求失败'));
        }
      }
      
      // 如果后端直接返回数据（不是 BaseResponse 结构）
      return response;
    },
    (error: AxiosError) => {
      // 隐藏 loading
      if ((error.config as RequestConfig)?.showLoading !== false) {
        console.log('隐藏 loading');
      }

      // 处理后端返回的错误状态码
      if (error.response) {
        const { status, statusText } = error.response;
        
        let errorMessage = '请求失败';
        
        switch (status) {
          case 400:
            errorMessage = '请求参数错误';
            break;
          case 401:
            errorMessage = '未授权，请重新登录';
            // 可以跳转到登录页
            break;
          case 403:
            errorMessage = '拒绝访问';
            break;
          case 404:
            errorMessage = '请求的资源不存在';
            break;
          case 500:
            errorMessage = '服务器内部错误';
            break;
          case 502:
            errorMessage = '网关错误';
            break;
          case 503:
            errorMessage = '服务不可用';
            break;
          case 504:
            errorMessage = '网关超时';
            break;
          default:
            errorMessage = statusText || `请求错误: ${status}`;
        }

        if ((error.config as RequestConfig)?.showError !== false) {
          console.error('HTTP错误:', errorMessage);
        }
      } else if (error.request) {
        // 请求已发出但没有收到响应
        if ((error.config as RequestConfig)?.showError !== false) {
          console.error('网络错误:', '请检查网络连接');
        }
      } else {
        // 请求配置错误
        if ((error.config as RequestConfig)?.showError !== false) {
          console.error('请求配置错误:', error.message);
        }
      }

      return Promise.reject(error);
    }
  );



  return instance;
};

// 创建默认实例
const http = createAxiosInstance();

// 封装的请求方法get post
class HttpRequest {
  private axiosInstance: AxiosInstance;

  constructor(baseURL?: string) {
    this.axiosInstance = createAxiosInstance(baseURL);
  }

  /**
   * GET 请求
   */
  async get<T = any>(
    url: string,
    params?: Record<string, any>,
    config?: RequestConfig
  ): Promise<T> {

    const response = await this.axiosInstance.get<BaseResponse<T>>(url, {
      params,
      ...config,
    });
    
    // 提取 data 字段
    const data = response.data;
    if (data && typeof data === 'object' && 'data' in data) {
      return data.data;
    }
    return data as T;
  }

  /**
   * POST 请求
   */
  async post<T = any>(
    url: string,
    data?: any,
    config?: RequestConfig
  ): Promise<T> {
    const response = await this.axiosInstance.post<BaseResponse<T>>(url, data, config);
    
    const responseData = response.data;
    if (responseData && typeof responseData === 'object' && 'data' in responseData) {
      return responseData.data;
    }
    return responseData as T;
  }

//   /**
//    * PUT 请求
//    */
//   async put<T = any>(
//     url: string,
//     data?: any,
//     config?: RequestConfig
//   ): Promise<T> {
//     const response = await this.axiosInstance.put<BaseResponse<T>>(url, data, config);
    
//     const responseData = response.data;
//     if (responseData && typeof responseData === 'object' && 'data' in responseData) {
//       return responseData.data;
//     }
//     return responseData as T;
//   }

//   /**
//    * DELETE 请求
//    */
//   async delete<T = any>(
//     url: string,
//     params?: Record<string, any>,
//     config?: RequestConfig
//   ): Promise<T> {
//     const response = await this.axiosInstance.delete<BaseResponse<T>>(url, {
//       params,
//       ...config,
//     });
    
//     const responseData = response.data;
//     if (responseData && typeof responseData === 'object' && 'data' in responseData) {
//       return responseData.data;
//     }
//     return responseData as T;
//   }

  /**
   * PATCH 请求
   */
  async patch<T = any>(
    url: string,
    data?: any,
    config?: RequestConfig
  ): Promise<T> {
    const response = await this.axiosInstance.patch<BaseResponse<T>>(url, data, config);
    
    const responseData = response.data;
    if (responseData && typeof responseData === 'object' && 'data' in responseData) {
      return responseData.data;
    }
    return responseData as T;
  }

  /**
   * 上传文件
   */
  async upload<T = any>(
    url: string,
    formData: FormData,
    config?: RequestConfig
  ): Promise<T> {
    const response = await this.axiosInstance.post<BaseResponse<T>>(url, formData, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },
      ...config,
    });
    
    const responseData = response.data;
    if (responseData && typeof responseData === 'object' && 'data' in responseData) {
      return responseData.data;
    }
    return responseData as T;
  }

  /**
   * 下载文件
   */
  async download(
    url: string,
    params?: Record<string, any>,
    config?: RequestConfig
  ): Promise<Blob> {
    const response = await this.axiosInstance.get(url, {
      params,
      responseType: 'blob',
      ...config,
    });
    return response.data;
  }

  /**
   * 获取原始的 axios 实例
   */
  getInstance(): AxiosInstance {
    return this.axiosInstance;
  }
}

const request=new HttpRequest("http://localhost:5000/api");

// 导出默认实例
export default  request;

// // 也可以导出类，方便创建不同 baseURL 的实例
// export { HttpRequest };