import { Button } from "@/components/ui/button.tsx"
import { Input } from '@/components/ui/input.tsx'

export default function Login() {
  return (
      <div className='m-auto w-[25rem]'>
          <Input className='mb-4' type="email" placeholder="Email"/>
          <Input className='mb-4' type="password" placeholder="Password"/>
          <Button className='ml-auto px-8 mb-2'>
              Login
          </Button>
          <br/>
          <p>Not a user? &nbsp;
          <a className='text-link ml-auto hover:opacity-70' href="/register">Register</a>
          </p>
      </div>
  )
}
